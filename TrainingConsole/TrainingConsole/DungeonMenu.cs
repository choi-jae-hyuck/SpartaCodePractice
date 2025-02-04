namespace TrainingConsole;

public class DungeonMenu
{
    public List<Dungeon> Dungeons;

    public DungeonMenu(List<Dungeon> dungeons)
    {
        Dungeons = dungeons;
    }


    public void DungeonInfo(Warrior warrior)
    {
        while (true)
        {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            int idx = 1;
            foreach (var dungeon in Dungeons)
            {
                Console.WriteLine("{0}. {1} |  방어력 {2}이상 권장", idx, dungeon.Name, dungeon.Hard);
                idx++;
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.Write("원하시는 행동을 입력해주세요.");
            int playerAction = int.Parse(Console.ReadLine());
            if (playerAction == 0) return;
            else if (0 < playerAction && playerAction <= Dungeons.Count)
            {
                if (warrior.Health <= 0)
                {
                    Console.WriteLine("체력이 없습니다 회복하고 오세요");
                    return;
                }
                Dungeons[playerAction - 1].DungeonIn(warrior);
            }
            else
                Console.WriteLine("잘못된 입력입니다");
        }
    }

   
    
}