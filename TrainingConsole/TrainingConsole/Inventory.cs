namespace TrainingConsole;

public class Inventory
{
    public void ShowItem(Warrior warrior, List<Item> items)
    {
        while (true)
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            foreach (var item in items)
            {
                if (item.Have)
                {
                    Console.Write("- ");
                    item.DisplayItem();
                }
            }

            Console.WriteLine("");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("2. 나가기");
            Console.WriteLine("");

            Console.Write("원하시는 행동을 선택하십시오 : ");
            int playerAction = int.Parse(Console.ReadLine());

            switch (playerAction)
            {
                case 1 :
                    SelectItem(warrior, items);
                    break;
                case 2 :
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    break;
            }
        }
    }

    

    public void SelectItem(Warrior warrior, List<Item> items)
    {

        while (true)
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            for (var index = 0; index < items.Count; index++)
            {
                var item = items[index];
                if (item.Have)
                {
                    Console.Write("- ");
                    Console.Write("{0} ", index + 1);
                    item.DisplayItem();
                }
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            Console.Write("원하시는 행동을 선택하십시오 : ");
            int playerAction = int.Parse(Console.ReadLine());

            if (playerAction == 0) return;
            if (playerAction <= items.Count && items[playerAction - 1].Have)
            {

                foreach (var item in items)
                {
                    if (item.Type == items[playerAction - 1].Type && item.Equip && item != items[playerAction-1])
                    {
                        item.Equip = false;
                        warrior.AddEquip(-item.Attack,-item.Defence);
                    }
                }
                
                items[playerAction - 1].Equip = !items[playerAction - 1].Equip;
                if(items[playerAction - 1].Equip)
                    warrior.AddEquip(items[playerAction - 1].Attack,items[playerAction - 1].Defence);
                else
                    warrior.AddEquip(-items[playerAction - 1].Attack,-items[playerAction - 1].Defence);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
            }
        }
    }
}