using HyperGnosys.ExternalizableProperty;
using HyperGnosys.NullObjectPattern;
using HyperGnosys.SerializedInterface;
using UnityEngine;

namespace HyperGnosys.Skills
{
    /// <summary>
    /// Basado en http://wiki.unity3d.com/index.php?title=RigidbodyFPSWalker&_ga=2.185744041.1811558816.1590246550-1529894449.1573125252#C.23_-_RigidbodyFPSController.cs
    /// </summary>
    public class JumpSkillComponent : MonoBehaviour
    {
        [SerializeField] private bool debugJumpSkill = false;
        [Tooltip("El objeto debe tener Collider y Rigidbody")]
        [SerializeField] private GameObject objectThatJumps = NullObjectPatternReferences.NoGameObject;

        [SerializeField] private ExternalizableLabeledProperty<float> jumpHeight = new ExternalizableLabeledProperty<float>();
        [Tooltip("Hace su propia llamada de IsGrounded porque el Slope de contacto para poder saltar " +
            "es diferente al de caminar")]
        [SerializeField] private ExternalizableLabeledProperty<float> canJumpFloorContact = new ExternalizableLabeledProperty<float>();
        [SerializeField] private ExternalizableLabeledProperty<bool> shouldJump = new ExternalizableLabeledProperty<bool>();

        [Space]
        [SerializeField] private SerializedInterface<IJumpSkillBehaviour> jumpBehaviour = new SerializedInterface<IJumpSkillBehaviour>();

        private Rigidbody objectRigidBody;
        private Collider objectCollider;
        private float gravity = -Physics.gravity.y;

        private void Reset()
        {
            jumpHeight.Value = 2;
            canJumpFloorContact.Value = 0.1f;
            shouldJump.Value = true;
        }
        private void OnValidate()
        {
            if (objectThatJumps == null)
            {
                return;
            }
            objectRigidBody = objectThatJumps.GetComponent<Rigidbody>();
        }
        void Awake()
        {
            if (objectThatJumps != null)
            {
                objectRigidBody = objectThatJumps.GetComponent<Rigidbody>();
                objectCollider = objectThatJumps.GetComponent<Collider>();
                objectRigidBody.freezeRotation = true;
            }
        }
        public void OnJump(bool isJumpInputDown)
        {
            if (isJumpInputDown && ColliderIsGrounded.IsGrounded(objectCollider, canJumpFloorContact.Value,
                canJumpFloorContact.Value, debugJumpSkill))
            {
                shouldJump.Value = true;
            }
        }
        public void FixedUpdate()
        {
            if (shouldJump.Value)
            {
                jumpBehaviour.Reference.Jump(objectRigidBody, jumpHeight.Value);
                shouldJump.Value = false;
            }
        }
        public bool Debugging { get => debugJumpSkill; set => debugJumpSkill = value; }
        public GameObject ObjectThatJumps { get => objectThatJumps; set => objectThatJumps = value; }
        public ExternalizableLabeledProperty<float> JumpHeight { get => jumpHeight; set => jumpHeight = value; }
        public ExternalizableLabeledProperty<float> CanJumpFloorContact { get => canJumpFloorContact; set => canJumpFloorContact = value; }
        public ExternalizableLabeledProperty<bool> CanJump { get => shouldJump; set => shouldJump = value; }
        public Rigidbody ObjectRigidBody { get => objectRigidBody; set => objectRigidBody = value; }
        public Collider ObjectCollider { get => objectCollider; set => objectCollider = value; }
        public float Gravity { get => gravity; set => gravity = value; }
    }
}