using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public Transform itemRoot;

    public Button btnConfirm; 
    public Button[] btnItems;
    public Button[] btns;

    // public UIShopItem[] uiItems;

    private void Start()
    {
        btns = GetComponentsInChildren<Button>();
        btnConfirm = btns[0];

        //uiItems = GetComponentsInChildren<UIShopItem>();

        for (int i = 0; i < ShopManager.itemDatas.Length; i++)
        {
            ShopItem item = ShopManager.itemDatas[i];
            //uiItems[i].SetItemInfo(item.itemName, item.itemPrice);
            
            Object itemObejct = Resources.Load("btnItem");                              // ���ҽ� �ε�
            GameObject itemGameObejct = (GameObject)Instantiate(itemObejct, itemRoot);  // �ε�� ���� ����

            UIShopItem uiShopItem = itemGameObejct.GetComponent<UIShopItem>();          // ������ ���ҽ����� �ʿ��� �Ӽ� ã��
            uiShopItem.SetRefence();
            uiShopItem.SetItemInfo(item);        // ã���� �Ӽ��� ���� �Է�
        }
    }
}
