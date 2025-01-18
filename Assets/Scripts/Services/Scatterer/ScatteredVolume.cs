using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public class ScatteredVolume : MonoBehaviour, IComparable<ScatteredVolume>
    {

        private const int MaxStep = 10000, DelayForNext = 20;
        [SerializeField] private List<TagChain> tagChains;
        [SerializeField] private float padding = 0.1f;
        [SerializeField] private int lenght = 5;
        [SerializeField] private int width = 1;
        [field: SerializeField] public int Capacity { get; private set; } = 10;


        private Vector3 firstDir;
        private Vector3 secondDir;
        private List<ScatteredItem> items = new List<ScatteredItem>();

        public void Init()
        {

            Vector3 firstDir, secondDir;
            Vector3 scale = transform.localScale * 0.5f;

            if (scale.x > scale.z)
            {
                firstDir = new Vector3(scale.x, 0, 0);
                secondDir = new Vector3(0, 0, scale.z);
            }
            else
            {
                firstDir = new Vector3(0, 0, scale.z);
                secondDir = new Vector3(scale.x, 0, 0);
            }

            firstDir = Rotate(transform.rotation.eulerAngles, firstDir);
            secondDir = Rotate(transform.rotation.eulerAngles, secondDir);
            this.firstDir = firstDir;
            this.secondDir = secondDir;
            items.Clear();
        }

        private Vector3 Rotate(Vector3 rotate, Vector3 dir)
        {
            Vector3 rotatedDir = Quaternion.AngleAxis(rotate.x, Vector3.right) * dir;
            rotatedDir = Quaternion.AngleAxis(rotate.y, Vector3.up) * rotatedDir;
            rotatedDir = Quaternion.AngleAxis(rotate.z, Vector3.forward) * rotatedDir;
            return rotatedDir;
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

        public void ScatterItem(bool withUpdate)
        {
            if (items == null || items.Count == 0) return;
            if (!withUpdate) ScatterViaSimulation();
            else ScatterViaFixedUpdate();
        }

        private void ScatterViaSimulation()
        {
            Physics.autoSyncTransforms = false;
            var prev = Physics.simulationMode;
            Physics.simulationMode = SimulationMode.Script;

            var position = GetPosition(0);
            items[0].Launch(position);

            for (int i = 0, k = 1; i < MaxStep; i++)
            {
                Physics.Simulate(Time.fixedDeltaTime);
                var allIsSleeping = items.All(x => x.IsSleeping());
                if (allIsSleeping && items.All(x => x.IsActiveSelf()))
                {
                    Physics.simulationMode = prev;
                    Physics.autoSyncTransforms = true;
                    return;
                }

                if (k < items.Count && (i % DelayForNext == 0 || allIsSleeping))
                {
                    position = GetPosition(k);
                    items[k].Launch(position);
                    k++;
                }
            }
            Debug.LogWarning($"Something keeps falling, {name}");

            Physics.simulationMode = prev;
            Physics.autoSyncTransforms = true;
        }

        private bool useFixedUpadete = false;
        private int currentStep;
        private int currentItem;
        private TaskCompletionSource<bool> tcs;
        private async void ScatterViaFixedUpdate()
        {
            var position = GetPosition(0);
            items[0].Launch(position);
            currentStep = 0;
            currentItem = 1;
            tcs = new TaskCompletionSource<bool>();
            useFixedUpadete = true;
            await tcs.Task;
        }

        private void FixedUpdate()
        {
            if (!useFixedUpadete) return;
            if (currentStep >= MaxStep)
            {
                useFixedUpadete = false;
                tcs.SetResult(true);
            }
            var allIsSleeping = items.All(x => x.IsSleeping());
            if (allIsSleeping && items.All(x => x.IsActiveSelf()))
            {
                useFixedUpadete = false;
                tcs.SetResult(true);
            }
            if (currentItem < items.Count && (currentStep % DelayForNext == 0 || allIsSleeping))
            {
                var position = GetPosition(currentItem);
                items[currentItem].Launch(position);
                currentItem++;
            }
            currentStep++;
        }

        private Vector3 GetPosition(int index)
        {

            var firstPercent = GetPercent(index % lenght, lenght);
            var secondPercent = GetPercent(index / lenght % width, width);
            return transform.position - firstDir * firstPercent - secondDir * secondPercent;
        }

        private float GetPercent(int index, int count)
        {
            var length = 1 - padding;
            if (count == 1) return 0;
            if (count == 2)
            {
                if (index == 0) return -length / 3.0f;
                if (index == 1) return length / 3.0f;
            }

            float step = length * 2.0f / (count - 1);

            if (count % 2 == 0)
            {
                var middle1 = count / 2;
                float halfStep = step * 0.5f;
                if (index < middle1)
                {
                    return (index - middle1) * step + halfStep;
                }
                else
                {
                    return (index - middle1 + 1) * step - halfStep;
                }
            }
            else
            {
                var middle1 = count / 2;
                return (index - middle1) * step;
            }

        }

        public int CompareTo(ScatteredVolume other)
        {
            return Capacity > other.Capacity ? 1 : Capacity == other.Capacity ? 0 : -1;
        }
    }
}