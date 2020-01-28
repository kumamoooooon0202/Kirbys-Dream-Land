using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChange : MonoBehaviour
{
    private Text text;
    [SerializeField] private float time;
    public ColorType colorType;

    // enumで管理出来たらいいなぁ
    public enum ColorType
    {
        r,
        g,
        b,
    }

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.color = ColorChange(text.color);
    }

    private Color ColorChange(Color color)
    {
        time += Time.deltaTime * 5.0f;
        color.r = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }
    //private Color ColorSelect()
    //{
    //    switch (colorType)
    //    {
    //        case ColorType.r:
    //            text.color = new Color(1, 0, 0, 1);
    //            break;

    //        case ColorType.g:
    //            text.color = new Color(0, 1, 0, 1);
    //            break;

    //        case ColorType.b:
    //            text.color = new Color(0, 0, 1, 1);
    //            break;
    //    }

    //    return text.color;
    //}

}
