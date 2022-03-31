using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public abstract class ASingleObjectRot : ARotObject
    {
        [SerializeField] private GameObject objectToRotate;
        [SerializeField] private ExternalizableLabeledProperty<float> maxRotation;
        protected Vector2 currentRotation = Vector2.zero;

        protected GameObject ObjectToRotate { get => objectToRotate; set => objectToRotate = value; }
        public ExternalizableLabeledProperty<float> MaxRotation { get => maxRotation; private set => maxRotation = value; }
    }
}