using HyperGnosys.ExternalizableProperty;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private float multiplier = 2;
    [SerializeField] private ExternalizableLabeledProperty<float> speed 
        = new ExternalizableLabeledProperty<float>();

    public void OnBoost(int runInputState)
    {
        if (runInputState == 2)
        {
            speed.Value *= multiplier;
        }
        if (runInputState == 4)
        {
            speed.Value /= multiplier;
        }
    }
}
