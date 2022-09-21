using UnityEngine;

namespace HyperGnosys.Skills
{
    public class SingleObjectYRot : ASingleObjectRot
    {
        protected override void Look(Vector2 rotate)
        {
            if (rotate.sqrMagnitude < 0.01 || ObjectToRotate == null)
            {
                return;
            }
            float scaledRotateSpeed = RotateSpeed.Value * Time.deltaTime;
            currentRotation.x -= rotate.y * scaledRotateSpeed;
            if (MaxRotation.Value > 0)
            {
                currentRotation.x = Mathf.Clamp(currentRotation.x, -MaxRotation.Value, MaxRotation.Value);
            }
            ObjectToRotate.transform.localEulerAngles = currentRotation;
        }
    }
}