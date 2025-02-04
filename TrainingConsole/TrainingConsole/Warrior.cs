namespace TrainingConsole;

public class Warrior
{
    public int Level;
    public string Name;
    public string Job;
    public float Attack;
    public float Defence;
    public int Health;
    public int Gold;
    public int Exp;

    public int EquipAttack;
    public int EquipDefence;
    
    public Warrior(string name, int job)
    {
        Level = 1;
        Name = name;

        switch (job)
        {
            case 1 :
                Job = "전사";
                Health = 100; Attack = 10; Defence = 5;
                break;
            case 2 :
                Job = "도적";
                Health = 70; Attack = 20; Defence = 1;
                break;
            case 3 :
                Job = "마법사";
                Health = 50; Attack = 15; Defence = 3;
                break;
        }
        Gold = 15000;
        Exp = 0;

        EquipAttack = 0;
        EquipDefence = 0;
        
    }
    
    public void AddEquip(int E_attack,int E_defence)
    {
        EquipAttack += E_attack;
        EquipDefence += E_defence;
    }

    public void LevelUp()
    {
        Exp++;
        if (Exp == Level)
        {
            Exp = 0;
            Level += 1;
            Attack += 0.5f;
            Defence += 1;
        }
    }
    
    public void ShowPlayer()
    {
        while (true)
        {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            ShowInfo();
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
    
    public void ShowInfo()
    {
        Console.WriteLine("이름 : {0}", Name);
        Console.WriteLine("Lv : {0}", Level);
        Console.WriteLine("Chad : {0}", Job);
        Console.Write("공격력 : {0}", Attack + EquipAttack);
        Console.WriteLine(" (+{0})", EquipAttack);
        Console.Write("방어력 : {0}", Defence + EquipDefence);
        Console.WriteLine(" (+{0})", EquipDefence);
        Console.WriteLine("체력 : {0}", Health);
        Console.WriteLine("Gold : {0}", Gold);
        Console.WriteLine("EXP : {0} / {1}", Exp, Level);
    }
    
    

}