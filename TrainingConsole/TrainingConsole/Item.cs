namespace TrainingConsole;

public class Item
{
    public string Name;
    public bool Equip;             // 아이템 장비중인지 확인
    public bool Have;              // 아이템 소지중인지 확인
    public string Explanation;     // 아이템 설명
    public int Gold;               // 아이템 가격

    public int ATTACK;
    public int DEFENCE;

    public Item(string name,string explanation, int attack, int defence, int gold)
    {
        Name = name;
        Explanation = explanation;
        ATTACK = attack;
        DEFENCE = defence;
        Gold = gold;
    }

    public void DisplayItem()
    {
        if (Equip)
            Console.Write("[E]");
        Console.Write("{0} ", Name);
        if (ATTACK > 0)
            Console.Write("| 공격력  +{0}  ", ATTACK);
        if (DEFENCE > 0)
            Console.Write("| 방어력  +{0}  ", DEFENCE);
        Console.WriteLine("| {0}  ", Explanation);
    }

    public void DisplayItemShop()
    {
        Console.Write("{0} ", Name);
        if (ATTACK > 0)
            Console.Write("| 공격력  +{0}  ", ATTACK);
        if (DEFENCE > 0)
            Console.Write("| 방어력  +{0}  ", DEFENCE);
        Console.Write("| {0}  ", Explanation);
        if (!Have)
            Console.WriteLine("| {0}G", Gold);
        else if (Have)
            Console.WriteLine("| 구매완료");
    }
    
    
}