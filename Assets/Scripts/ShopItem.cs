public class ShopItem
{
    public string itemName;
    public int itemPrice;
    public int itemAtk; // ���ݷ�
    public int itemHp; // ü��

    public ShopItem(string name, int price, int atk)
    {
        itemName = name;
        itemPrice = price;
        itemAtk = atk;
    }
}