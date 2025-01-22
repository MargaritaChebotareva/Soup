using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public class ScatterSeparated : IScatterType
    {
        private int columns;
        private int rows;
        private float padding;
        private Vector3 longSideDir;
        private Vector3 shortSideDir;
        private bool isSeparatedByRows;
        private bool isSeparatedByColumns;
        private List<ScatteredItem> items;
        private List<ItemType> itemTypes;

        private class ItemType
        {
            public string name;
            public int count;
            public int prefixSum;
            public int index;
            public int lastItemIndex;
        }

        public void Refresh(Vector3 localScale, Quaternion rotation, int columns, int rows, float padding, bool isSeparatedByRows, bool isSeparatedByColumns, List<ScatteredItem> items)
        {
            this.columns = columns;
            this.rows = rows;
            this.padding = padding;
            Utils.GetDirectionsForScatteredVolume(localScale, rotation, out longSideDir, out shortSideDir);
            this.isSeparatedByRows = isSeparatedByRows;
            this.isSeparatedByColumns = isSeparatedByColumns;
            this.items = items;
            PrepareItemTypes();
        }

        private void PrepareItemTypes()
        {
            itemTypes = new List<ItemType>();
            foreach (var item in items)
            {
                if (itemTypes.Count == 0 || !itemTypes.Exists(x => x.name == item.name))
                {
                    itemTypes.Add(new ItemType { name = item.name, index = itemTypes.Count });
                }
            }

            int prefixSum = 0;
            foreach (var itemType in itemTypes)
            {
                var count = items.Count(x => x.name == itemType.name);
                itemType.count = count;
                itemType.prefixSum = prefixSum;
                prefixSum += count;
            }
        }

        public Vector3 GetPosition(int index, Vector3 center)
        {
            var type = itemTypes[itemTypes.FindIndex(x => x.name == items[index].name)];

            var itemIndex = type.lastItemIndex;
            type.lastItemIndex++;


            int colIndex = 0, rowIndex = 0;
            if (isSeparatedByRows)
            {
                var rowCount = rows / itemTypes.Count;
                var columnCount = columns;

                var rowIndexBegin = type.prefixSum / type.count * rowCount;
                var rowIndexEnd = (type.prefixSum + type.count) / type.count * rowCount - 1;
                rowIndex = rowIndexBegin + (itemIndex % (rowIndexEnd - rowIndexBegin + 1));
                colIndex = itemIndex / (rowIndexEnd - rowIndexBegin + 1);
                colIndex = colIndex % columns;
            }
            else if (isSeparatedByColumns)
            {
                var rowCount = rows;
                var columnCount = columns / itemTypes.Count;

                var colIndexBegin = type.prefixSum / type.count * columnCount;
                var colIndexEnd = (type.prefixSum + type.count) / type.count * columnCount - 1;
                colIndex = colIndexBegin + (itemIndex % (colIndexEnd - colIndexBegin + 1));
                rowIndex = itemIndex / (colIndexEnd - colIndexBegin + 1);
                rowIndex = rowIndex % rows;
            }

            var longSidePercent = Utils.GetPercent(colIndex, columns, padding);
            var shortSidePercent = Utils.GetPercent(rowIndex, rows, padding);
            return center - longSideDir * longSidePercent - shortSideDir * shortSidePercent;
        }
    }
}