using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public class TwoObjectVector2RotAround : ATwoObjectRot
    {
        [SerializeField] private int maxXRotation = 30;

        private Vector2 currentYRotation = Vector2.zero;
        private Vector2 currentXRotation = Vector2.zero;

        private void Awake()
        {
        }
        protected override void Look(Vector2 rotate)
        {
            if (rotate.sqrMagnitude < 0.01 || XRotObject == null || YRotObject == null)
            {
                return;
            }
            float scaledRotateSpeed = RotateSpeed.Value * Time.deltaTime;
            currentYRotation.y += rotate.x * scaledRotateSpeed;
            YRotObject.transform.localEulerAngles = currentYRotation;

            currentXRotation.x = Mathf.Clamp(currentXRotation.x - rotate.y * scaledRotateSpeed, -maxXRotation, maxXRotation);
            XRotObject.transform.RotateAround(YRotObject.transform.position, XRotObject.transform.right, currentXRotation.x);
        }
    }
}