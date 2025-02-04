namespace TrainingConsole;

public class Dungeon
{
    public string Name;
    public int Hard;
    public int Reward;

    public Dungeon(string name, int hard, int reward)
    {
        Name = name;
        Hard = hard;
        Reward = reward;
    }

    public static void DungeonInitialize(List<Dungeon> dungeons)
    {
        dungeons.Add(new Dungeon("쉬운 던전", 5, 1000));
        dungeons.Add(new Dungeon("일반 던전", 11, 1700));
        dungeons.Add(new Dungeon("어려운 던전", 17, 2500));
    }
    
    
    public void DungeonIn(Warrior warrior)
    {
        Random rand = new Random();

        if (warrior.Defence + warrior.EquipDefence < Hard)
        {
            int i = rand.Next(1, 10 + 1);
            if (i < 5)
                DungeonFail(warrior);
            else
                DungeonClear(warrior);
        }
        else
        {
            DungeonClear(warrior);
        }
        
    }
    
    public void DungeonClear(Warrior warrior)
    {
        Random rand = new Random();

        int rHealth = rand.Next(20, 35 + 1) - (int)warrior.Defence;
        warrior.Health -= rHealth;
        if (warrior.Health < 0)
        {
            int swap = warrior.Health + rHealth;
            warrior.Health = 0;
            rHealth = swap;
        }
        
        int rGold = Reward + (int)(rand.Next( (int)(warrior.Attack + warrior.EquipAttack), 
                                    (int)(warrior.Attack + warrior.EquipAttack) * 2 - 1 ) * Reward * 0.01f);
        warrior.Gold += rGold;
        warrior.LevelUp();
        
        while (true)
        {
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine("{0}을 클리어 하였습니다.", Name);
            Console.WriteLine("");
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine("체력 {0} -> {1}", warrior.Health + rHealth, warrior.Health);
            Console.WriteLine("Gold {0} -> {1}", warrior.Gold - rGold, warrior.Gold);
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.Write("원하시는 행동을 입력해주세요.");
            int playerAction = int.Parse(Console.ReadLine());
            if (playerAction == 0) return;
            else
                Console.WriteLine("잘못된 입력입니다");
        }
    }

    public void DungeonFail(Warrior warrior)
    {
        warrior.Health /= 2;
        
        while (true)
        {
            Console.WriteLine("던전 클리어 실패");
            Console.WriteLine("체력 {0} -> {1}", warrior.Health * 2, warrior.Health);
            Console.WriteLine("0. 나가기");            
            Console.Write("원하시는 행동을 입력해주세요.");
            int playerAction = int.Parse(Console.ReadLine());
            if (playerAction == 0) return;
            else
                Console.WriteLine("잘못된 입력입니다");
            
        }
    }
    
}