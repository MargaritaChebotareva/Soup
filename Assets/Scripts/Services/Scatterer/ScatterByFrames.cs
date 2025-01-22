using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public class ScatterByFrames
    {
        private bool enable = false;
        private int currentStep;
        private int currentItem;
        private TaskCompletionSource<bool> tcs;
        private IScatterType scatter;
        private List<ScatteredItem> items;
        private string name;
        public bool Enable => enable;

        public async void Start(List<ScatteredItem> items, Vector3 center, IScatterType scatter, string name)
        {
            this.items = items;
            this.scatter = scatter;
            this.name = name;
            var position = scatter.GetPosition(0, center);
            items[0].Launch(position);
            currentStep = 0;
            currentItem = 1;
            tcs = new TaskCompletionSource<bool>();
            enable = true;
            await tcs.Task;
        }

        public void Update(Vector3 center)
        {
            if (!enable) return;
            if (currentStep >= ScatteredVolume.MaxStep)
            {
                enable = false;
                tcs.SetResult(true);
                Debug.LogWarning($"Something keeps falling, {name}");
            }
            var allIsSleeping = items.All(x => x.IsSleeping());
            if (allIsSleeping && items.All(x => x.IsActiveSelf()))
            {
                enable = false;
                tcs.SetResult(true);
            }
            if (currentItem < items.Count && (currentStep % ScatteredVolume.DelayForNext == 0 || allIsSleeping))
            {
                var position = scatter.GetPosition(currentItem, center);
                items[currentItem].Launch(position);
                currentItem++;
            }
            currentStep++;
        }
    }
}