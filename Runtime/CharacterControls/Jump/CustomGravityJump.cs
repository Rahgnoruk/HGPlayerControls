using HyperGnosys.ExternalizableProperty;
using UnityEngine;

namespace HyperGnosys.Skills
{
    [CreateAssetMenu]
    public class CustomGravityJump : ScriptableObject, IJumpSkillBehaviour
    {
        [SerializeField] private ExternalizableLabeledProperty<float> customGravity;

        public void Jump(Rigidbody jumpingRigidbody, float jumpHeight)
        {
            float yVelocity = CalculateJumpVerticalSpeed(jumpHeight);
            Vector3 jumpVector = new Vector3(jumpingRigidbody.velocity.x, yVelocity, jumpingRigidbody.velocity.z);
            jumpingRigidbody.AddForce(jumpVector, ForceMode.VelocityChange);
        }
        private float CalculateJumpVerticalSpeed(float jumpHeight)
        {
            // From the jump height and gravity we deduce the upwards speed 
            // for the character to reach at the apex.
            return Mathf.Sqrt(2 * jumpHeight * customGravity.Value);
        }
    }
}