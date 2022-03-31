using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HyperGnosys.Input
{
    public class XYZInputToVector3 : AEventComponent<InputAction.CallbackContext>
    {
        [SerializeField] private UnityEvent<Vector3> raiseVector3 = new UnityEvent<Vector3>();
        public override void Raise(InputAction.CallbackContext context)
        {
            Vector3 inputVector = context.ReadValue<Vector3>();
            raiseVector3?.Invoke(inputVector);
            base.Raise(context);
        }
    }
}