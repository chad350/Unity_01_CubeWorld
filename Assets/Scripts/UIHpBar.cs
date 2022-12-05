using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBar : MonoBehaviour
{
    public Slider hpBar;

    private float curHp;

    public void SetTotalHP(int hp)
    {
        hpBar.maxValue = hp;
        hpBar.value = hp;
    }

    public void SetCurHP(int hp)
    {
        curHp = hp;
    }

    private void Update()
    {
        if (hpBar.value > curHp)
        {
            hpBar.value -= 0.1f;
        }

        if (hpBar.value < curHp)
        {
            hpBar.value += 0.1f;
        }
    }
}
