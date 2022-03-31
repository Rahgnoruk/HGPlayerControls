using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material material;

    private int colorCounter = 0;
    private Color[] colors = { Color.blue, Color.red, Color.green, Color.black, Color.cyan, Color.magenta };

    void Awake()
    {
        material.EnableKeyword("_EMISSION");
    }
    public void ChangeColor(bool performed)
    {
        if (!performed) return;
        if (colorCounter >= colors.Length - 1)
        {
            colorCounter = 0;
        }
        else
        {
            colorCounter++;
        }
        material.SetColor("_EmissionColor", colors[colorCounter]);
    }
}
