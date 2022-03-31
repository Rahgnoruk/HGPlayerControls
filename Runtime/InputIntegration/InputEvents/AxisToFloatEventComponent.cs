using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HyperGnosys.Input
{
    public class AxisToFloatEventComponent : AEventComponent<InputAction.CallbackContext>
    {
        [SerializeField] private UnityEvent<float> raiseVector3 = new UnityEvent<float>();
        public override void Raise(InputAction.CallbackContext context)
        {
            float axis = context.ReadValue<float>();
            raiseVector3?.Invoke(axis);
            base.Raise(context);
        }
    }
}