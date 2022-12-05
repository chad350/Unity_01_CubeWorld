using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public string enemyName;

    public int HP = 10;
    public int Atk = 3;

    public int Cost = 64;

    [HideInInspector]
    public UINickname uiNickname;
    UIHpBar uiHpBar;
    private void Start()
    {
        // ���� �Ҵ�
        Object nickname = Resources.Load("UINickName");
        Instantiate(nickname, transform);

        uiNickname = GetComponentInChildren<UINickname>();
        uiNickname.SetName(enemyName);

        // ���ҽ� �ε�
        Object hpBar = Resources.Load("UIHpBar");
        Instantiate(hpBar, transform);

        // ������ ����
        uiHpBar = GetComponentInChildren<UIHpBar>();

        // Ȱ��
        uiHpBar.SetTotalHP(HP);
        uiHpBar.SetCurHP(HP);
    }

    public void OnDamaged(CubePlayer player)
    {
        HP -= player.Atk;
        
        uiHpBar.SetCurHP(HP);
        
        if (HP <= 0)
        {
            HP = 0;
            player.GetMoney(Cost);
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die : " + enemyName);
        Destroy(gameObject);
    }
}
