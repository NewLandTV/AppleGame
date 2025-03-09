using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textNumber;
    private Image image;
    private RectTransform rect;

    private int number = 0;
    public int Number
    {
        get => number;
        set
        {
            number = value;
            textNumber.text = number.ToString();
        }
    }

    public Vector3 Position => rect.position;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnSelected()
    {
        image.color = Color.blue;
    }

    public void OnDeselected()
    {
        image.color = Color.red;
    }
}
