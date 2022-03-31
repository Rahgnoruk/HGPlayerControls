using HyperGnosys.Core;
using UnityEngine;

public class RaycastIsGrounded : MonoBehaviour
{
    /// Debugging no se debe marcar como solo de editor porque IsGrounded lo usa
    [SerializeField] private bool debugging = false;
    [SerializeField] private ExternalizableLabeledProperty<bool> isGrounded;
    [SerializeField] private Collider objectCollider;
    [SerializeField] private ExternalizableLabeledProperty<float> floorSlope;

    private void FixedUpdate()
    {
        isGrounded.Value = ColliderIsGrounded.IsGrounded(ObjectCollider, FloorSlope.Value,
            FloorSlope.Value, Debugging);
    }
    public bool Debugging { get => debugging; set => debugging = value; }
    public Collider ObjectCollider { get => objectCollider; set => objectCollider = value; }
    public ExternalizableLabeledProperty<float> FloorSlope { get => floorSlope; set => floorSlope = value; }
    public ExternalizableLabeledProperty<bool> IsGrounded { get => isGrounded; set => isGrounded = value; }
}