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
        // 동적 할당
        Object nickname = Resources.Load("UINickName");
        Instantiate(nickname, transform);

        uiNickname = GetComponentInChildren<UINickname>();
        uiNickname.SetName(enemyName);

        // 리소스 로드
        Object hpBar = Resources.Load("UIHpBar");
        Instantiate(hpBar, transform);

        // 실제로 생성
        uiHpBar = GetComponentInChildren<UIHpBar>();

        // 활용
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
