using System.Text.Json.Serialization;

namespace TrainingConsole;

public class Warrior
{
    [JsonPropertyName("Level")]
    public int Level { get; set; }
    [JsonPropertyName("Name")]
    public string Name{ get; set; }
    [JsonPropertyName("Job")]
    public string Job{ get; set; }
    [JsonPropertyName("Attack")]
    public float Attack{ get; set; }
    [JsonPropertyName("Defence")]
    public float Defence{ get; set; }
    [JsonPropertyName("Health")]
    public int Health{ get; set; }
    [JsonPropertyName("Gold")]
    public int Gold{ get; set; }
    [JsonPropertyName("Exp")]
    public int Exp{ get; set; }

    [JsonPropertyName("EquipAttack")]
    public int EquipAttack{ get; set; }
    [JsonPropertyName("EquipDefence")]
    public int EquipDefence{ get; set; }
    
    public Warrior(string name, int jobtype)
    {
        Level = 1;
        Name = name;

        switch (jobtype)
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
            Console.WriteLine("");
            Console.WriteLine("LEVEL UP");
            Thread.Sleep(1000);
        }
    }
    
    public void ShowPlayer()
    {
        while (true)
        {
            Console.Clear();
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
                    Thread.Sleep(1000);
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