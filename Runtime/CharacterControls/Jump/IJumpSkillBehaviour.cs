using UnityEngine;

namespace HyperGnosys.Skills
{
    public interface IJumpSkillBehaviour
    {
        void Jump(Rigidbody jumpingRigidbody, float jumpHeight);
    }
}