using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{    
    static GameObject shop = null;

    public static ShopItem[] itemDatas =
    {
        new ShopItem("도란검", 100, 3),
        new ShopItem("롱소드", 150, 4),
        new ShopItem("도란방패", 100, 0),
        new ShopItem("루비수정", 150, 0),
    };

    public static void OpenShopUI()
    {
        // 상점이 null 일때만 ui 생성
        if (shop == null)
        {
            Object shopObject = Resources.Load("UIShop");
            shop = (GameObject)Instantiate(shopObject);
        }

        shop.SetActive(true);
    }

    public static void CloseShopUI()
    {
        if (shop != null)
        {
            shop.SetActive(false);
        }
    }
}