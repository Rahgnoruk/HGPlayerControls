using HyperGnosys.ExternalizableProperty;
using UnityEngine;

public class RigidbodyVelocityObserver : MonoBehaviour
{
    [SerializeField] private bool debugging = true;
    [SerializeField] private Rigidbody observedRigidbody;
    [SerializeField] private ExternalizableLabeledProperty<float> xVelocity;
    [SerializeField] private ExternalizableLabeledProperty<float> zVelocity;
    private Vector3 localVelocityVector = Vector3.zero;
    private Vector3 cachedVelocity = Vector3.zero;


    private void FixedUpdate()
    {
        if (observedRigidbody.velocity == cachedVelocity)
        {
            return;
        }
        cachedVelocity = observedRigidbody.velocity;
        LocalVelocityVector = observedRigidbody.transform.InverseTransformDirection(observedRigidbody.velocity);
        
        XVelocity.Value = LocalVelocityVector.x;
        ZVelocity.Value = LocalVelocityVector.z;
    }
    public ExternalizableLabeledProperty<float> XVelocity { get => xVelocity; set => xVelocity = value; }
    public ExternalizableLabeledProperty<float> ZVelocity { get => zVelocity; set => zVelocity = value; }
    public Vector3 LocalVelocityVector { get => localVelocityVector; set => localVelocityVector = value; }
    public Rigidbody ObservedRigidbody { get => observedRigidbody; set => observedRigidbody = value; }
    public Vector3 CachedVelocity { get => cachedVelocity; set => cachedVelocity = value; }
}