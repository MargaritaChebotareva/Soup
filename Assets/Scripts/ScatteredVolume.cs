using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScatteredVolume : MonoBehaviour{
    [SerializeField] private GameObject label;
    [SerializeField] private int[] types;
    [SerializeField] private float padding = 0.1f;
    private Vector3 firstDir;
    private Vector3 secondDir;
    private List<ScatteredItem> items = new List<ScatteredItem>();

    public void Init(){
        
        Vector3 firstDir, secondDir;
        Vector3 scale = transform.localScale * 0.5f;

        if(scale.x > scale.z){
            firstDir = new Vector3(scale.x, 0, 0);
            secondDir = new Vector3(0, 0, scale.z);
        }
        else{
            firstDir = new Vector3(0, 0, scale.z);
            secondDir = new Vector3(scale.x, 0, 0);
        }

        firstDir = Rotate(transform.rotation.eulerAngles, firstDir);
        secondDir = Rotate(transform.rotation.eulerAngles, secondDir);
        this.firstDir = firstDir;
        this.secondDir = secondDir;
    }

    private Vector3 Rotate(Vector3 rotate, Vector3 dir){
        Vector3 rotatedDir = Quaternion.AngleAxis(rotate.x, Vector3.right) * dir;
        rotatedDir = Quaternion.AngleAxis(rotate.y, Vector3.up) * rotatedDir;
        rotatedDir = Quaternion.AngleAxis(rotate.z, Vector3.forward) * rotatedDir;
        return rotatedDir;
    }

    public bool CanAddItemToVolume(ScatteredItem item)
    {
        return types.Contains(item.Type);
    }

    public void AddItem(ScatteredItem item)
    {
        items.Add(item);
    }

    public void ScatterItem()
    {
        List<Rigidbody> rigidBodies = items.Select(x => x.GetRigidbody()).ToList();

        Physics.autoSyncTransforms = false;
        var prev = Physics.simulationMode;
        Physics.simulationMode = SimulationMode.Script;

        var position = GetPosition(items[0].Type);
        items[0].Launch(position);

        const int maxStep = 10000, delayForNext = 20;
        for (int i = 0, k = 1; i < maxStep; i++)
        {            
            Physics.Simulate(Time.fixedDeltaTime);
            var allIsSleeping = rigidBodies.All(x => x.IsSleeping());
            if (allIsSleeping && rigidBodies.All(x => x.gameObject.activeSelf))
            {
                Debug.Log($"Nothing fell past, {name}, iteration {i}");
                break;
            }

            if (k < items.Count && (i % delayForNext == 0 || allIsSleeping))
            {
                position = GetPosition(items[k].Type);
                items[k].Launch(position);
                k++;
            }
        }

        Physics.simulationMode = prev;
        Physics.autoSyncTransforms = true;
    }

    private Vector3 GetPosition(int currentType)
    {
        var firstPercent = GetPercent(Array.IndexOf(types, currentType), types.Length);
        return transform.position - firstDir * firstPercent;// - volume.SecondDir * secondPercent;;// transform.position;
    }
    
    private float GetPercent(int id, int count)
    {
        var length = 1 - padding;
        if (count == 1) return 0;
        if (count == 2)
        {
            if (id == 0) return -length / 3.0f;
            if (id == 1) return length / 3.0f;
        }

        float step = length * 2.0f / (count - 1);

        if (count % 2 == 0)
        {
            var middle1 = count / 2;
            float halfStep = step * 0.5f;
            if (id < middle1)
            {
                return (id - middle1) * step + halfStep;
            }
            else
            {
                return (id - middle1 + 1) * step - halfStep;
            }
        }
        else
        {
            var middle1 = count / 2;
            return (id - middle1) * step;
        }

    }
}