namespace TrainingConsole;

class Program
{
    static void Main(string[] args)
    {
        Warrior warrior = new Warrior("Player","전사");
        List<Item> items = new List<Item>();

        Shop shop = new Shop();
        Sleep sleep = new Sleep();

        items.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, 1000));
        items.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 2000));
        items.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",0, 15, 3500));
        items.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0, 600));
        items.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 0, 1500));
        items.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 2000));
        items.Add(new Item("용사의 검", "아방 스트랏슈~", 10, 10, 5000));
        
            
        int playerAction;
        while (true)
        {
            Console.WriteLine("마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("5. 휴식하기");
            Console.Write("원하시는 행동을 선택하십시오 : ");

            playerAction = int.Parse(Console.ReadLine());

            switch (playerAction)
            {
                case 1:
                    ShowPlayer(warrior);
                    break;
                case 2:
                    ShowItem(warrior, items);
                    break;
                case 3:
                    shop.ShowShop(warrior, items);
                    break;
                case 4 :
                    break;
                case 5 :
                    sleep.RestInfo(warrior);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
            }

            // break; //게임종료
        }
        
        

    }
    
    static void ShowPlayer(Warrior warrior)
    {
        while (true)
        {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            warrior.ShowInfo();
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            Console.Write("원하시는 행동을 선택하십시오 : ");
            int playerAction = int.Parse(Console.ReadLine());
            switch (playerAction)
            {
                case 0:
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
            }
        }

    }
    
    static void ShowItem(Warrior warrior, List<Item> items)
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

    

    static void SelectItem(Warrior warrior, List<Item> items)
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
                items[playerAction - 1].Equip = !items[playerAction - 1].Equip;
                if(items[playerAction - 1].Equip)
                    warrior.AddEquip(items[playerAction - 1].ATTACK,items[playerAction - 1].DEFENCE);
                else
                    warrior.AddEquip(-items[playerAction - 1].ATTACK,-items[playerAction - 1].DEFENCE);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
            }
        }
    }
    
    
    
    
    
}