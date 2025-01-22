using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public interface IScatterType
    {
        public Vector3 GetPosition(int index, Vector3 center);
    }
}