using HyperGnosys.ExternalizableProperty;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public class RigidbodyMoveComponent : MonoBehaviour
    {
        [SerializeField] private bool debugRigidbodyMove = false;
        [Space]
        [Header("GameObject que se mueve")]
        [Header("Debe tener rigidbody y collider")]
        [SerializeField] private Transform objectToMove;[Space]
        [SerializeField, HideInInspector] private Rigidbody objectRigidBody;

        [Space]
        [Header("Movement Config")]
        [SerializeField] private ExternalizableLabeledProperty<float> speed = new ExternalizableLabeledProperty<float>();
        [SerializeField] private ExternalizableLabeledProperty<bool> moveInAir = new ExternalizableLabeledProperty<bool>();
        [SerializeField] private ExternalizableLabeledProperty<bool> instantStop = new ExternalizableLabeledProperty<bool>();
        [Tooltip("Si la cámara sigue al jugador hazlo verdadero")]
        [SerializeField] private ExternalizableLabeledProperty<bool> moveInTransformsDirection = new ExternalizableLabeledProperty<bool>();
        [Tooltip("Cambio máximo en velocidad de un frame al siguiente")]
        [SerializeField] private ExternalizableLabeledProperty<float> maxVelocityChange = new ExternalizableLabeledProperty<float>();

        [Space]
        [Header("State Variables")]
        [SerializeField] private ExternalizableLabeledProperty<bool> isGrounded = new ExternalizableLabeledProperty<bool>();
        [SerializeField] private ExternalizableLabeledProperty<bool> canMove = new ExternalizableLabeledProperty<bool>();
        [Header("Los siguientes atributos se actualizaran con " +
            "las velocidades del movimiento. Si quieres la velocidad " +
            "exacta del Rigidbody, mejor usa el RigidbodyVelocityObserver")]
        [SerializeField] private ExternalizableLabeledProperty<float> targetVelocityX = new ExternalizableLabeledProperty<float>();
        [SerializeField] private ExternalizableLabeledProperty<float> targetVelocityZ = new ExternalizableLabeledProperty<float>();
        
        private Vector3 targetVelocityVector;

        private void Reset()
        {
            canMove.Value = true;
            speed.Value = 10f;
            moveInAir.Value = true;
            instantStop.Value = true;
            moveInTransformsDirection.Value = true;
            maxVelocityChange.Value = 10f;
            isGrounded.Value = true;
        }
        private void OnValidate()
        {
            if (objectToMove == null)
            {
                return;
            }
            objectRigidBody = objectToMove.GetComponent<Rigidbody>();
        }
        private void Awake()
        {
            if (objectToMove == null)
            {
                return;
            }
        }
        public void OnMove(Vector3 targetVelocityVector)
        {
            this.targetVelocityVector = targetVelocityVector;
        }
        public void FixedUpdate()
        {
            if (!canMove.Value) return;
            Move(targetVelocityVector);
        }

        public void Move(Vector3 targetVector)
        {
            bool targetIsStopping = targetVector.sqrMagnitude < 0.01;
            if (targetIsStopping)
            {
                targetVelocityX.Value = 0;
                targetVelocityZ.Value = 0;

                if (instantStop.Value)
                    InstantStop();
                return;
            }
            if (HasControl)
            {
                targetVector *= speed.Value;
                if (moveInTransformsDirection.Value)
                {
                    targetVector = VectorInWorldCoods(targetVector);
                }
                targetVelocityX.Value = targetVector.x;
                targetVelocityZ.Value = targetVector.z;

                GraduallyAddVelocity(targetVector);
            }
        }
        private void InstantStop()
        {
            bool rigidbodyStillMoving = objectRigidBody.velocity.x != 0 || objectRigidBody.velocity.z != 0;
            if (rigidbodyStillMoving && HasControl)
            {
                objectRigidBody.velocity = new Vector3(0, objectRigidBody.velocity.y, 0);
            }
        }
        private bool HasControl => moveInAir.Value || isGrounded.Value;
        private Vector3 VectorInWorldCoods(Vector3 targetVector)
        {
            return objectToMove.TransformDirection(targetVector);
        }
        private void GraduallyAddVelocity(Vector3 targetVector)
        {
            Vector3 currentVelocity = objectRigidBody.velocity;
            Vector3 velocityChange = targetVector - currentVelocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange.Value, maxVelocityChange.Value);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange.Value, maxVelocityChange.Value);
            velocityChange.y = 0;
            objectRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}