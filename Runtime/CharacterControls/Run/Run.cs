using HyperGnosys.ExternalizableProperty;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public class Run : MonoBehaviour
    {
        [SerializeField] private ExternalizableLabeledProperty<float> speedAttribute;

        public ExternalizableLabeledProperty<float> SpeedAttribute { get => speedAttribute; set => speedAttribute = value; }

        public void OnRun(int runInputState)
        {
            if (runInputState == 2)
            {
                speedAttribute.Value *= 2;
            }
            if (runInputState == 4)
            {
                speedAttribute.Value /= 2;
            }
        }
    }
}