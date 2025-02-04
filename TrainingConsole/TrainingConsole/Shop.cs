namespace TrainingConsole;
public class Shop
{
    public void ShowShop(Warrior warrior, List<Item> items)
    {
        while (true)
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유골드]");
            Console.WriteLine("{0} G", warrior.Gold);
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            foreach (var item in items)
            {
                item.DisplayItemShop();
            }

            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            Console.Write("원하시는 행동을 선택하십시오 : ");
            int playerAction = int.Parse(Console.ReadLine());

            switch (playerAction)
            {
                case 0:
                    return;
                case 1:
                    BuyItem(ref warrior.Gold, items);
                    break;
                case 2:
                    SellItem(warrior, items);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
            }
        }

    }

    public void BuyItem(ref int Gold, List<Item> items)
    {

        while (true)
        {
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유골드]");
            Console.WriteLine("{0} G",Gold);
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            for (var index = 0; index < items.Count; index++)
            {
                var item = items[index];
                Console.Write("- ");
                Console.Write("{0} ", index + 1);
                item.DisplayItemShop();
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            Console.Write("원하시는 행동을 선택하십시오 : ");
            int playerAction = int.Parse(Console.ReadLine());

            if (playerAction == 0) return;
            if (playerAction <= items.Count)
            {
                if (!items[playerAction - 1].Have)
                {
                    if (Gold > items[playerAction - 1].Gold)
                    {
                        items[playerAction - 1].Have = !items[playerAction - 1].Have;
                        Gold -= items[playerAction - 1].Gold;
                        Console.WriteLine("구매를 완료했습니다");
                    }
                    else
                        Console.WriteLine("Gold 가 부족합니다.");

                }

                else if (items[playerAction - 1].Have)
                {
                    Console.WriteLine("이미 구매한 아이템입니다");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
            }
        }


    }

    public void SellItem(Warrior warrior, List<Item> items)
    {
        while (true)
        {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유골드]");
            Console.WriteLine("{0} G", warrior.Gold);
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
                items[playerAction - 1].Have = !items[playerAction - 1].Have;
                warrior.Gold += (int)(items[playerAction - 1].Gold * 0.85f);
                if (items[playerAction - 1].Equip)
                {
                    items[playerAction - 1].Equip = false;
                    warrior.AddEquip(-items[playerAction - 1].Attack, -items[playerAction - 1].Defence);
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
            }
        }
    }
}