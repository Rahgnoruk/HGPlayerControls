using HyperGnosys.Core;
using UnityEngine;

public class CollisionIsGrounded : MonoBehaviour
{
    [SerializeField] private bool debugging = true;
    public bool Debugging { get => debugging; set => debugging = value; }
    
    
    [SerializeField] private ExternalizableLabeledProperty<bool> isGrounded;
    public ExternalizableLabeledProperty<bool> IsGrounded { get => isGrounded; set => isGrounded = value; }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded.Value = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded.Value = true;
    }
}