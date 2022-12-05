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
            
            Object itemObejct = Resources.Load("btnItem");                              // 리소스 로드
            GameObject itemGameObejct = (GameObject)Instantiate(itemObejct, itemRoot);  // 로드된 것을 생성

            UIShopItem uiShopItem = itemGameObejct.GetComponent<UIShopItem>();          // 생성된 리소스에서 필요한 속성 찾기
            uiShopItem.SetRefence();
            uiShopItem.SetItemInfo(item);        // 찾아준 속성에 정보 입력
        }
    }
}
