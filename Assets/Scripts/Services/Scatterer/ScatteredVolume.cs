using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public partial class ScatteredVolume : MonoBehaviour, IComparable<ScatteredVolume>
    {
        public const int MaxStep = 10000, DelayForNext = 20;
        [SerializeField] private List<TagChain> tagChains;
        [SerializeField] private float padding = 0.1f;
        [SerializeField] private int columns = 5;
        [SerializeField] private int rows = 1;
        [SerializeField] private bool isSeparatedByRows = false;
        [SerializeField] private bool isSeparatedByColumns = false;
        [field: SerializeField] public int Capacity { get; private set; } = 10;

        private List<ScatteredItem> items = new List<ScatteredItem>();

        private readonly ScatterMixed scatterMixed = new ScatterMixed();
        private readonly ScatterSeparated scatterSeparated = new ScatterSeparated();
        private readonly ScatterByFrames scatterByFrames = new ScatterByFrames();
        private readonly ScatterBySimulation scatterBySimulation = new ScatterBySimulation();

        public void Init()
        {
            items.Clear();
        }

        public bool CanAddItemToVolume(ScatteredItem item)
        {
            if (item.TagChain == null || item.TagChain.IsEmpty() || items.Count >= Capacity) return false;
            foreach (var tagsChain in tagChains)
            {
                var tagsChainWithoutItem = tagsChain.tags.Except(item.TagChain.tags);
                var itemWithoutTagsChain = item.TagChain.tags.Except(tagsChain.tags);
                if (!tagsChainWithoutItem.Any() && !itemWithoutTagsChain.Any()) return true;

            }
            return false;
        }

        public void AddItem(ScatteredItem item)
        {
            items.Add(item);
        }

        public int CompareTo(ScatteredVolume other)
        {
            return Capacity > other.Capacity ? 1 : Capacity == other.Capacity ? 0 : -1;
        }

        public void ScatterItem(bool byFrame)
        {
            if (items == null || items.Count == 0) return;

            IScatterType scatterType;
            if (isSeparatedByColumns || isSeparatedByRows)
            {
                scatterSeparated.Refresh(transform.localScale, transform.rotation, columns, rows, padding, isSeparatedByRows, isSeparatedByColumns, items);
                scatterType = scatterSeparated;
            }
            else
            {
                scatterMixed.Refresh(transform.localScale, transform.rotation, columns, rows, padding);
                scatterType = scatterMixed;
            }

            if (byFrame) scatterByFrames.Start(items, transform.position, scatterType, name);
            else scatterBySimulation.Start(items, transform.position, scatterType, name);
        }

        private void FixedUpdate()
        {
            if (scatterByFrames.Enable)
            {
                scatterByFrames.Update(transform.position);
            }
        }

    }
}