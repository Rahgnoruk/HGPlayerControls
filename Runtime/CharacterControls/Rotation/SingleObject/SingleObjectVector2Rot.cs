using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Skills
{
    // Update orientation first, then move. Otherwise move orientation will lag
    // behind by one frame.
    public class SingleObjectVector2Rot : ASingleObjectRot
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
            currentRotation.x = Mathf.Clamp(currentRotation.x - rotate.y * scaledRotateSpeed, -89, 89);
            ObjectToRotate.transform.localEulerAngles = currentRotation;
        }
    }
}