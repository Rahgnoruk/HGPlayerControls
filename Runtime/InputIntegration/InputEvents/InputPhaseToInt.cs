using HyperGnosys.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HyperGnosys.Input
{
    public class InputPhaseToInt : AEventComponent<InputAction.CallbackContext>
    {
        [SerializeField] private UnityEvent<int> onPhaseChanged = new UnityEvent<int>();
        public override void Raise(InputAction.CallbackContext context)
        {
            ///Disabled = 0, Waiting = 1, Started = 2, Performed = 3, Canceled = 4
            onPhaseChanged.Invoke((int)context.phase);
            base.Raise(context);
        }
    }
}