namespace TrainingConsole;

public enum TYPE
{
    ATTACK,
    DEFENCE
}

public class Item
{
    public string Name;
    public bool Equip;             // 아이템 장비중인지 확인
    public bool Have;              // 아이템 소지중인지 확인
    public string Explanation;     // 아이템 설명
    public int Gold;               // 아이템 가격

    public int Attack;
    public int Defence;
    public TYPE Type;

    public Item(string name,string explanation, int attack, int defence,TYPE type, int gold)
    {
        Name = name;
        Explanation = explanation;
        Attack = attack;
        Defence = defence;
        Type = type;
        Gold = gold;
    }

    public static void ItemInitialize(List<Item> items)
    {
        items.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, TYPE.DEFENCE, 1000));
        items.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, TYPE.DEFENCE, 2000));
        items.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",0, 15, TYPE.DEFENCE, 3500));
        items.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0, TYPE.ATTACK, 600));
        items.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 0, TYPE.ATTACK, 1500));
        items.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, TYPE.ATTACK, 2000));
        items.Add(new Item("용사의 검", "아방 스트랏슈~", 10, 10, TYPE.ATTACK, 5000));

    }
    

    public void DisplayItem()
    {
        if (Equip)
            Console.Write("[E]");
        Console.Write("{0} ", Name);
        if (Attack > 0)
            Console.Write("| 공격력  +{0}  ", Attack);
        if (Defence > 0)
            Console.Write("| 방어력  +{0}  ", Defence);
        Console.WriteLine("| {0}  ", Explanation);
    }

    public void DisplayItemShop()
    {
        Console.Write("{0} ", Name);
        if (Attack > 0)
            Console.Write("| 공격력  +{0}  ", Attack);
        if (Defence > 0)
            Console.Write("| 방어력  +{0}  ", Defence);
        Console.Write("| {0}  ", Explanation);
        if (!Have)
            Console.WriteLine("| {0}G", Gold);
        else if (Have)
            Console.WriteLine("| 구매완료");
    }
    
    
}