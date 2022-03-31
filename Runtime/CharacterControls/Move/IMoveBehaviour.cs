using UnityEngine;

namespace HyperGnosys.Skills
{
    public interface IMoveBehaviour
    {
        void Move(Vector3 targetVelocityVector, Transform objectToMove, Rigidbody rigidbody);
    }
}