using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public class ScatterBySimulation
    {
        public void Start(List<ScatteredItem> items, Vector3 center, IScatterType scatter, string name)
        {
            Physics.autoSyncTransforms = false;
            var prev = Physics.simulationMode;
            Physics.simulationMode = SimulationMode.Script;

            var position = scatter.GetPosition(0, center);
            items[0].Launch(position);

            for (int i = 0, k = 1; i < ScatteredVolume.MaxStep; i++)
            {
                Physics.Simulate(Time.fixedDeltaTime);
                var allIsSleeping = items.All(x => x.IsSleeping());
                if (allIsSleeping && items.All(x => x.IsActiveSelf()))
                {
                    Physics.simulationMode = prev;
                    Physics.autoSyncTransforms = true;
                    return;
                }

                if (k < items.Count && (i % ScatteredVolume.DelayForNext == 0 || allIsSleeping))
                {
                    position = scatter.GetPosition(k, center);
                    items[k].Launch(position);
                    k++;
                }
            }
            Debug.LogWarning($"Something keeps falling, {name}");

            Physics.simulationMode = prev;
            Physics.autoSyncTransforms = true;
        }
    }
}