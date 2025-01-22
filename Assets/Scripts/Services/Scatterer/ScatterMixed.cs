using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public class ScatterMixed : IScatterType
    {
        private int columns;
        private int rows;
        private float padding;
        private Vector3 longSideDir;
        private Vector3 shortSideDir;

        public void Refresh(Vector3 localScale, Quaternion rotation, int columns, int rows, float padding)
        {
            this.columns = columns;
            this.rows = rows;
            this.padding = padding;
            Utils.GetDirectionsForScatteredVolume(localScale, rotation, out longSideDir, out shortSideDir);
        }
        public Vector3 GetPosition(int index, Vector3 center)
        {
            var colIndex = index % columns;
            var rowIndex = index / columns;
            var loopedRowIndex = rowIndex % rows;
            var longSidePercent = Utils.GetPercent(colIndex, columns, padding);
            var shortSidePercent = Utils.GetPercent(loopedRowIndex, rows, padding);
            return center - longSideDir * longSidePercent - shortSideDir * shortSidePercent;
        }
    }
}