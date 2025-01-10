using Assets.Scripts.Prefabs;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemScatterer : MonoBehaviour
{
    [SerializeField] private ScatteredVolume[] volumes;

    public void Scatter(Dictionary<int, Ingredient> ingredientObjects)
    {
        if (volumes == null || volumes.Length <= 0) return;
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
            volumes[i].ScatterItem();
        }

        sw.Stop();
        Debug.Log($"End of scatter, time = {TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)}");
    }
}
