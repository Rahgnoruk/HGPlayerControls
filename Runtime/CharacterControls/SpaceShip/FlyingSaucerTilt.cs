using UnityEngine;

public class FlyingSaucerTilt : MonoBehaviour {
    [SerializeField] private bool debugSaucerTilt = false;
    [SerializeField] private Transform graphics;
    [SerializeField] private float tilt = 10f;
    [SerializeField] private float animTime = 1;

    private Vector3 inputVector;
    private Quaternion targetRot = Quaternion.identity;
    private float increment = 0;

    public void FixedUpdate()
    {
        Tilt();
    }
    public void Tilt(Vector3 inputVector)
    {
        this.inputVector = inputVector;
        increment = 0;
    }
    private void Tilt()
    {
        targetRot = Quaternion.Euler(tilt * (inputVector.z), 0, tilt * (-inputVector.x));
        if (increment < 1)
           increment += Time.deltaTime;
        graphics.localRotation = Quaternion.Lerp(graphics.localRotation, targetRot, increment);
    }
}
