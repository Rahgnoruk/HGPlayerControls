using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public class SingleObjectXRot : ASingleObjectRot
    {
        private void Awake()
        {
            if (ObjectToRotate == null)
            {
                HGDebug.LogError(transform.name + " no tiene el objeto a rotar asignado", Debugging);
            }
        }
        protected override void Look(Vector2 rotate)
        {
            if (rotate.sqrMagnitude < 0.01 || ObjectToRotate == null)
            {
                return;
            }
            var scaledRotateSpeed = RotateSpeed.Value * Time.deltaTime;
            currentRotation.y += rotate.x * scaledRotateSpeed;
            if (MaxRotation.Value > 0)
            {
                currentRotation.y = Mathf.Clamp(currentRotation.y, -MaxRotation.Value, MaxRotation.Value);
            }
            ObjectToRotate.transform.localEulerAngles = currentRotation;
        }
    }
}