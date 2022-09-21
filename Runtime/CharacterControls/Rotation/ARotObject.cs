using HyperGnosys.ExternalizableProperty;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public abstract class ARotObject : MonoBehaviour
    {
        [SerializeField] private bool debugging = false;
        [SerializeField] private ExternalizableLabeledProperty<float> rotateSpeed = new ExternalizableLabeledProperty<float>();
        private Vector2 lookVector = Vector2.zero;

        protected virtual void Reset()
        {
            rotateSpeed.Value = 6;
        }

        public void OnLook(Vector2 lookVector)
        {
            this.lookVector = lookVector;
        }
        public void Update()
        {
            Look(LookVector);
        }
        protected bool Debugging { get => debugging; set => debugging = value; }
        protected abstract void Look(Vector2 rotation);
        protected ExternalizableLabeledProperty<float> RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }
        protected Vector2 LookVector { get => lookVector; set => lookVector = value; }
    }
}