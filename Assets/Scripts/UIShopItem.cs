using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public Button btnItem; // button
    public Text txtName;   // text 이름 - 아이템의 이름
    public Text txtPrice;  // text 가격 - 아이템의 가격

    public Image imgItem;  // iamge

    // Image 
    // Text  

    ShopItem itemData;
    
    public void SetRefence()
    {
        btnItem = GetComponent<Button>();
        btnItem.onClick.AddListener(BuyItem);

        // texts - 3
        // 0 : txtItemName
        // 1 : txtItemCost
        // 2 : txtItemOption
        Text[] texts = GetComponentsInChildren<Text>();

        txtName = texts[0];
        txtPrice = texts[1];
    }

    public void SetItemInfo(ShopItem data)
    {
        itemData = data;        
        txtName.text = itemData.itemName;
        // txtPrice.text = itemPrice + "g";
        txtPrice.text = $"{itemData.itemPrice}g";

        Sprite sp = Resources.Load<Sprite>("doran"); // 리소스 로드
        imgItem.sprite = sp;

        // Instantiate()   <- 실제로 만들어서 씬(하이어라키)로 올리는 부분
    }

    void BuyItem() {
        // 얼마인지 체크를 해야하고
        // price <- 얼마인지 체크

        // 캐릭터가 가지고 있는돈이 얼마인지 체크
        // PlayerManager.Player.money

        
        bool can = PlayerManager.Player.CanBuy(itemData.itemPrice);

        // 조건식 -> bool

        if ((itemData.itemPrice-20) >= PlayerManager.Player.money)
        {
            // 아이템 구매
            PlayerManager.Player.SpendMoney(itemData.itemPrice);
            Debug.Log($"아이템 이름 : {name} 을 구매했습니다.");

            // 아이템 옵션만큼 캐릭터 능력치 더해주면 됩니다.
            PlayerManager.Player.IncreaseAtk(itemData.itemAtk);
        }
        else
        {
            // 구매 실패
            Debug.Log($"돈이 부족합니다.  필요한 돈 : {itemData.itemPrice}    소지금 : {PlayerManager.Player.money}");
        }
    }
}
