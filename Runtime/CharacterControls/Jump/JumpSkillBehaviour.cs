using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Skills
{
    [CreateAssetMenu(fileName = "New Jump Skill Behaviour", menuName = "HyperGnosys/Skills/Jump")]
    public class JumpSkillBehaviour : ScriptableObject
    {
        [SerializeField] private ExternalReference<IJumpSkillBehaviour> jumpBehaviour 
            = new ExternalReference<IJumpSkillBehaviour>();
        public void Jump(Rigidbody jumpingRigidbody, float jumpHeight)
        {
            jumpBehaviour.Reference.Jump(jumpingRigidbody, jumpHeight);
        }
    }
}