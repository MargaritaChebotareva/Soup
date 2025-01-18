using Assets.Scripts.Prefabs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public class ItemScatterer : MonoBehaviour
    {
        [SerializeField] private ScatteredVolume[] volumes;
        [SerializeField] private bool withUpdate = false;
        private Dictionary<int, Ingredient> ingredientObjects;

        public void Scatter(Dictionary<int, Ingredient> ingredientObjects)
        {
            this.ingredientObjects = ingredientObjects;
            if (volumes == null || volumes.Length <= 0) return;

            Array.Sort(volumes);
            for (int i = 0; i < volumes.Length; i++)
            {
                volumes[i].Init();
            }

            var ingredients = ingredientObjects.Values;
            foreach (var ingredient in ingredients)
            {
                var item = ingredient.GetComponent<ScatteredItem>();
                for (int k = 0; k < volumes.Length; k++)
                {
                    if (volumes[k].CanAddItemToVolume(item))
                    {
                        volumes[k].AddItem(item);
                        break;
                    }
                }
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < volumes.Length; i++)
            {
                volumes[i].ScatterItem(withUpdate);
            }

            sw.Stop();
            Debug.Log($"End of scatter, time = {TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)}");
        }

        [ContextMenu("Reset items")]
        public void ResetItems()
        {
            foreach (var item in ingredientObjects.Values)
            {
                item.gameObject.SetActive(false);
                item.transform.position = default;
                item.transform.rotation = default;
            }
        }

        [ContextMenu("Repeat Scatter")]
        public void RepeatScatter()
        {
            Scatter(ingredientObjects);
        }
    }
}