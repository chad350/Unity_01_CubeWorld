using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINickname : MonoBehaviour
{
    public Image bg;
    public Text txt;

    Color originColor;

    void Awake()
    {
        bg = GetComponentInChildren<Image>();
        txt = GetComponentInChildren<Text>();

        originColor = bg.color;
    }

    public void SetName(string name)
    {
        txt.text = name;
    }

    public void SetColor(Color c)
    {
        bg.color = c;
    }

    public void SetOriginColor()
    {
        bg.color = originColor;
    }
}
