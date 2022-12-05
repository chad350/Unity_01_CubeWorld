public class ShopItem
{
    public string itemName;
    public int itemPrice;
    public int itemAtk; // 공격력
    public int itemHp; // 체력

    public ShopItem(string name, int price, int atk)
    {
        itemName = name;
        itemPrice = price;
        itemAtk = atk;
    }
}