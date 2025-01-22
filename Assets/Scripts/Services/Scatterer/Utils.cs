using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    public static class Utils
    {
        public static float GetPercent(int index, int count, float padding)
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

        public static void GetDirectionsForScatteredVolume(Vector3 localScale, Quaternion rotation, out Vector3 longSideDir, out Vector3 shortSideDir)
        {
            Vector3 scale = localScale * 0.5f;

            if (scale.x > scale.z)
            {
                longSideDir = new Vector3(scale.x, 0, 0);
                shortSideDir = new Vector3(0, 0, scale.z);
            }
            else
            {
                longSideDir = new Vector3(0, 0, scale.z);
                shortSideDir = new Vector3(scale.x, 0, 0);
            }

            longSideDir = Rotate(rotation.eulerAngles, longSideDir);
            shortSideDir = Rotate(rotation.eulerAngles, shortSideDir);
        }

        private static Vector3 Rotate(Vector3 rotate, Vector3 dir)
        {
            Vector3 rotatedDir = Quaternion.AngleAxis(rotate.x, Vector3.right) * dir;
            rotatedDir = Quaternion.AngleAxis(rotate.y, Vector3.up) * rotatedDir;
            rotatedDir = Quaternion.AngleAxis(rotate.z, Vector3.forward) * rotatedDir;
            return rotatedDir;
        }
    }
}