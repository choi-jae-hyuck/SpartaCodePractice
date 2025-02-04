﻿namespace TrainingConsole;

using Newtonsoft.Json;

class Program
{
    //할일 게임저장
    
    static void Main(string[] args)
    {
        
        Console.WriteLine("스파르타 던전에 오신걸 환영합니다");
        Console.WriteLine("원하시는 이름을 입력하세요");
        string playerName = Console.ReadLine();

        Console.WriteLine("입력하신 이름은 {0}입니다", playerName);
        
        int job = 1;
        while (true)
        {
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            Console.WriteLine("3. 마법사");
            Console.WriteLine("직업을 선택해주세요");
            string job_s = Console.ReadLine() ?? string.Empty;
            
            try
            {
                job = int.Parse(job_s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("");
                Console.WriteLine("잘못된 입력입니다 기본인 전사로 선택됩니다");
            }
            switch (job)
            {
                case 1 :
                    Console.WriteLine("선택된 직업은 전사입니다");
                    break;
                case 2 :
                    Console.WriteLine("선택된 직업은 도적입니다");
                    break;
                case 3 :
                    Console.WriteLine("선택된 직업은 마법사입니다");
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
            }
            break;
        }


        Warrior warrior = new Warrior(playerName, job);
        List<Item> items = new List<Item>();
        List<Dungeon> dungeons = new List<Dungeon>();
        Item.ItemInitialize(items);
        Dungeon.DungeonInitialize(dungeons);

        Inventory inventory = new Inventory();
        Shop shop = new Shop();
        Sleep sleep = new Sleep();
        DungeonMenu dungeonMenu = new DungeonMenu(dungeons);
        
        
        while (true)
        {
            Console.WriteLine("마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전탐색");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("");
            Console.WriteLine("0. 게임종료");
            Console.Write("원하시는 행동을 선택하십시오 : ");

            int playerAction = int.Parse(Console.ReadLine());

            switch (playerAction)
            {
                case 0 :
                    return;
                case 1:
                    warrior.ShowPlayer();
                    break;
                case 2:
                    inventory.ShowItem(warrior, items);
                    break;
                case 3:
                    shop.ShowShop(warrior, items);
                    break;
                case 4 :
                    dungeonMenu.DungeonInfo(warrior);
                    break;
                case 5 :
                    sleep.RestInfo(warrior);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
            }
            
        }
        
    }
    
}