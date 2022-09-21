using HyperGnosys.EventArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HyperGnosys.Input
{
    [CreateAssetMenu(fileName = "New Scritpable Input Event", menuName = "HyperGnosys/Events/Scritpable Input Event")]
    public class InputScriptableGameEvent : AScriptableEvent<InputAction.CallbackContext>
    {
    }
}