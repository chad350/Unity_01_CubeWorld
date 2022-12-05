using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ Ÿ�� - > 4���� Ÿ��
// �ִϸ��̼� -> 5���� �ִϸ��̼�
// ������ ���� -> 3�� ����
// ��ų - ����, Ÿ��

public enum NpcType {
    Shop,
    Heal
}

public class CubeNPC : MonoBehaviour
{
    public string npcName;
    public NpcType npcType = NpcType.Shop;

    [HideInInspector]
    public UINickname uiNickname;

    private void Start()
    {
        Object nickname = Resources.Load("UINickName");
        Instantiate(nickname, transform);

        uiNickname = GetComponentInChildren<UINickname>();
        uiNickname.SetName(npcName);
    }

    public void UseNPC(CubePlayer player)
    {       
        switch (npcType)
        {
            case NpcType.Shop:
                UseShopNPC();
                break;

            case NpcType.Heal:
                UseHealNPC(player);
                break;
        }
    }

    void UseShopNPC()
    {
        Debug.Log("�ȳ��ϼ���. ������ ��ϴ� NPC �Դϴ�.");

        ShopManager.OpenShopUI();
    }

    // Heal 
    void UseHealNPC(CubePlayer player)
    {
        // 5
        Debug.Log("�ȳ��ϼ���. ȸ���� ��ϴ� NPC �Դϴ�.");

        // if
        // ���� ����ϸ� ȸ��
        int healCost = 30;
        
        bool can = PlayerManager.Player.CanBuy(healCost);
        if ((healCost-15) >= PlayerManager.Player.money)
        {
            // ���� ���
            player.SpendMoney(healCost);
            
            // ȸ�� O
            int healAmount = 5;
            player.HealHp(healAmount);

            Object effect = Resources.Load("HealEffect");   // 1. ���ҽ� �ε�
            Instantiate(effect, player.transform);          // 2. �ε��� ���ҽ��� ������ ����
        }
        else
        {
            // ȸ�� X
            Debug.Log("CS �� �� ��������.");
        }     
    }
}