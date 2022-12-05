using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    public string playerName;
    public float speed = 10;
    
    public int HP = 20;
    public int Atk = 4;

    public int money = 0;

    UINickname uiNickname;
    UIHpBar uiHpBar;

    private void Start()
    {
        PlayerManager.Player = this;

        Object nickname = Resources.Load("UINickName");
        Instantiate(nickname, transform);        

        uiNickname = GetComponentInChildren<UINickname>();
        uiNickname.SetName(playerName);

        // 리소스 로드
        Object hpBar = Resources.Load("UIHpBar");
        Instantiate(hpBar, transform);

        // 실제로 생성
        uiHpBar = GetComponentInChildren<UIHpBar>();

        // 활용
        uiHpBar.SetTotalHP(HP);
        uiHpBar.SetCurHP(HP);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, 0, z) * 0.01f * speed;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();
        if (npc)
        {
            uiNickname.SetColor(Color.magenta);
            npc.uiNickname.SetColor(Color.magenta);

            npc.UseNPC(this);
            uiHpBar.SetCurHP(HP);
        }

        CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
        if (enemy)
        {
            uiNickname.SetColor(Color.red);
            enemy.uiNickname.SetColor(Color.red);

            OnDamaged(enemy.Atk);
            enemy.OnDamaged(this);
            uiHpBar.SetCurHP(HP);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();
        if (npc)
        {
            uiNickname.SetOriginColor();
            npc.uiNickname.SetOriginColor();

            ShopManager.CloseShopUI();
        }

        CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
        if (enemy)
        {
            uiNickname.SetOriginColor();
            enemy.uiNickname.SetOriginColor();
        }
    }

    public void OnDamaged(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0;
            Die();
        }       
    }

    void Die()
    {
        Debug.Log("Die : " + playerName);
        Destroy(gameObject);
    }

    public bool CanBuy(int money)
    {        
        // 롤 - > 외상 기능
        // 외상 -10원

        if(this.money >= (money - 10))
            return true;
        else
            return false;
    }

    public void GetMoney(int money)
    {
        this.money += money;
    }

    public void SpendMoney(int money)
    {
        this.money -= money;

        if (this.money < 0)
        {
            this.money = 0;
        }            
    }

    public void HealHp(int healAmount)
    {
        HP += healAmount;
    }

    public void IncreaseAtk(int value)
    {
        Atk += value;
    }    
}
