using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{    
    static GameObject shop = null;

    public static ShopItem[] itemDatas =
    {
        new ShopItem("������", 100, 3),
        new ShopItem("�ռҵ�", 150, 4),
        new ShopItem("��������", 100, 0),
        new ShopItem("������", 150, 0),
    };

    public static void OpenShopUI()
    {
        // ������ null �϶��� ui ����
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