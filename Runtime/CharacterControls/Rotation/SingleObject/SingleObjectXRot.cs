using UnityEngine;

namespace HyperGnosys.Skills
{
    public class SingleObjectXRot : ASingleObjectRot
    {
        protected override void Look(Vector2 rotate)
        {
            if (ObjectToRotate == null)
            {
                Debug.LogError(transform.name + " no tiene el objeto a rotar asignado", this);
                return;
            }
            if (rotate.sqrMagnitude < 0.01)
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