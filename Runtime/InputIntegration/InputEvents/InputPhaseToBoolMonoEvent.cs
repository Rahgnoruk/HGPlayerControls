using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputPhaseToBoolMonoEvent : AEventComponent<InputAction.CallbackContext>
{
    [SerializeField] private InputActionPhase truePhase = InputActionPhase.Performed;
    [SerializeField] private UnityEvent<bool> onPhaseChanged = new UnityEvent<bool>();
    public override void Raise(InputAction.CallbackContext context)
    {
        if(context.phase == truePhase)
        {
            onPhaseChanged.Invoke(true);
        }
        else
        {
            onPhaseChanged.Invoke(false);
        }
        base.Raise(context);
    }
}
