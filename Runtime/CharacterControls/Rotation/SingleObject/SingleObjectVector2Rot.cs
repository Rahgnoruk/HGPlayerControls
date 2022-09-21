using UnityEngine;

namespace HyperGnosys.Skills
{
    // Update orientation first, then move. Otherwise move orientation will lag
    // behind by one frame.
    public class SingleObjectVector2Rot : ASingleObjectRot
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
            currentRotation.x = Mathf.Clamp(currentRotation.x - rotate.y * scaledRotateSpeed, -89, 89);
            ObjectToRotate.transform.localEulerAngles = currentRotation;
        }
    }
}