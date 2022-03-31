using HyperGnosys.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HyperGnosys.Input
{
    public class InputToVector2MonoEvent : AEventComponent<InputAction.CallbackContext>
    {
        [SerializeField] private UnityEvent<Vector2> raiseVector2 = new UnityEvent<Vector2>();
        public override void Raise(InputAction.CallbackContext context)
        {
            Vector2 vector2 = context.ReadValue<Vector2>();
            raiseVector2?.Invoke(vector2);
            base.Raise(context);
        }
    }
}