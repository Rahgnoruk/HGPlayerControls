using HyperGnosys.SerializedInterface;
using UnityEngine;

namespace HyperGnosys.Skills
{
    [CreateAssetMenu(fileName = "New Jump Skill Behaviour", menuName = "HyperGnosys/Skills/Jump")]
    public class JumpSkillBehaviour : ScriptableObject
    {
        [SerializeField] private SerializedInterface<IJumpSkillBehaviour> jumpBehaviour 
            = new SerializedInterface<IJumpSkillBehaviour>();
        public void Jump(Rigidbody jumpingRigidbody, float jumpHeight)
        {
            jumpBehaviour.Reference.Jump(jumpingRigidbody, jumpHeight);
        }
    }
}