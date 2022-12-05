using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public Button btnItem; // button
    public Text txtName;   // text �̸� - �������� �̸�
    public Text txtPrice;  // text ���� - �������� ����

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

        Sprite sp = Resources.Load<Sprite>("doran"); // ���ҽ� �ε�
        imgItem.sprite = sp;

        // Instantiate()   <- ������ ���� ��(���̾��Ű)�� �ø��� �κ�
    }

    void BuyItem() {
        // ������ üũ�� �ؾ��ϰ�
        // price <- ������ üũ

        // ĳ���Ͱ� ������ �ִµ��� ������ üũ
        // PlayerManager.Player.money

        
        bool can = PlayerManager.Player.CanBuy(itemData.itemPrice);

        // ���ǽ� -> bool

        if ((itemData.itemPrice-20) >= PlayerManager.Player.money)
        {
            // ������ ����
            PlayerManager.Player.SpendMoney(itemData.itemPrice);
            Debug.Log($"������ �̸� : {name} �� �����߽��ϴ�.");

            // ������ �ɼǸ�ŭ ĳ���� �ɷ�ġ �����ָ� �˴ϴ�.
            PlayerManager.Player.IncreaseAtk(itemData.itemAtk);
        }
        else
        {
            // ���� ����
            Debug.Log($"���� �����մϴ�.  �ʿ��� �� : {itemData.itemPrice}    ������ : {PlayerManager.Player.money}");
        }
    }
}
