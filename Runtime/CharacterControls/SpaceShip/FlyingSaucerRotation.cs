using HyperGnosys.ExternalizableProperty;
using UnityEngine;

public class FlyingSaucerRotation : MonoBehaviour
{
    [SerializeField] private bool debugSaucerRotation = false;
    [SerializeField] private ExternalizableLabeledProperty<float> rotationSensitivity
        = new ExternalizableLabeledProperty<float>();
    [SerializeField] private ExternalizableLabeledProperty<float> lookSensitivity
        = new ExternalizableLabeledProperty<float>();
    [SerializeField] private bool invertY = false;
    [SerializeField] private FlyingSaucerBody body;

    float halfScreenWidth;
    float halfScreenHeight;

    private Vector2 lookVector = Vector2.zero;
    private float rotValue;
    protected virtual void Reset()
    {
        rotationSensitivity.Value = 10;
        lookSensitivity.Value = 2;
    }
    public void OnLook(Vector2 inputVector)
    {
        halfScreenWidth = Screen.width / 2;
        halfScreenHeight = Screen.height / 2;
        Vector2 screenCenter = new Vector2(halfScreenWidth, halfScreenHeight);
        lookVector = screenCenter - inputVector;
        ClampLookVector();
        lookVector = new Vector2(-lookVector.y, -lookVector.x);
    }
    private void ClampLookVector()
    {
        lookVector.y /= halfScreenHeight/2;
        lookVector.x /= halfScreenWidth/2;
    }
    public void OnRot(float rotValue)
    {
        this.rotValue = -rotValue;
    }
    public void Update()
    {
        Look();
    }

    public void Look()
    {
        float xRot = lookVector.x * lookSensitivity.Value;
        if (!invertY) xRot *= -1;
        float yRot = lookVector.y * lookSensitivity.Value;
        float zRot = rotValue * rotationSensitivity.Value;
        body.Body.Rotate(xRot, yRot, zRot, Space.Self);
    }
}