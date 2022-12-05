using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터의 타입 - > 4개의 타입
// 애니메이션 -> 5개의 애니메이션
// 아이템 종류 -> 3개 종류
// 스킬 - 범위, 타겟

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
        Debug.Log("안녕하세요. 상점을 운영하는 NPC 입니다.");

        ShopManager.OpenShopUI();
    }

    // Heal 
    void UseHealNPC(CubePlayer player)
    {
        // 5
        Debug.Log("안녕하세요. 회복을 운영하는 NPC 입니다.");

        // if
        // 돈이 충분하면 회복
        int healCost = 30;
        
        bool can = PlayerManager.Player.CanBuy(healCost);
        if ((healCost-15) >= PlayerManager.Player.money)
        {
            // 돈을 사용
            player.SpendMoney(healCost);
            
            // 회복 O
            int healAmount = 5;
            player.HealHp(healAmount);

            Object effect = Resources.Load("HealEffect");   // 1. 리소스 로드
            Instantiate(effect, player.transform);          // 2. 로드한 리소스를 실제로 생성
        }
        else
        {
            // 회복 X
            Debug.Log("CS 를 더 먹으세요.");
        }     
    }
}