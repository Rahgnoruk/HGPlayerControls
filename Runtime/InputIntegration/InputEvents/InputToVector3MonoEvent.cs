using HyperGnosys.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HyperGnosys.Input
{
    public class InputToVector3MonoEvent : AEventComponent<InputAction.CallbackContext>
    {
        [SerializeField] private UnityEvent<Vector3> raiseVector3 = new UnityEvent<Vector3>();
        public override void Raise(InputAction.CallbackContext context)
        {
            Vector2 vector2 = context.ReadValue<Vector2>();
            Vector3 vector3 = new Vector3(vector2.x, 0, vector2.y);
            raiseVector3?.Invoke(vector3);
            base.Raise(context);
        }
    }
}