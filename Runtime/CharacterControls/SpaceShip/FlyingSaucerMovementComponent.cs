using HyperGnosys.ExternalizableProperty;
using UnityEngine;
public class FlyingSaucerMovementComponent : MonoBehaviour
{
    [SerializeField] private bool debugSaucerMove = false;
    [SerializeField] private ExternalizableLabeledProperty<float> speed 
        = new ExternalizableLabeledProperty<float>();
    [SerializeField] private FlyingSaucerBody body;
    private Vector3 inputVector;
    private void Reset()
    {
        speed.Value = 2;
    }
    public void OnMove(Vector3 inputVector)
    {
        this.inputVector = inputVector;
    }
    public void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector3 sideMoveVector = body.Body.right * inputVector.x;
        Vector3 verticalMoveVector = body.Body.up * inputVector.y;
        Vector3 forwardMoveVector = body.Body.forward * inputVector.z;

        Vector3 moveVector = sideMoveVector + verticalMoveVector + forwardMoveVector;

        Vector3 resultingMovementVector = moveVector * speed.Value;
        body.Rigidbody.velocity = resultingMovementVector;
    }
}