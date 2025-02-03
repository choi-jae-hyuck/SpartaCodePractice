namespace TrainingConsole;

public class Warrior
{
    public int Level;
    public string Name;
    public string Job;
    public int Attack;
    public int Defence;
    public int Health;
    public int Gold;

    public int EquipAttack;
    public int EquipDefence;
    
    public Warrior(string name, string job)
    {
        Level = 1;
        Name = name;
        Job = job;
        Health = 100;
        Attack = 10;
        Defence = 5;
        Gold = 15000;

        EquipAttack = 0;
        EquipDefence = 0;
    }
    
    public void AddEquip(int E_attack,int E_defence)
    {
        EquipAttack += E_attack;
        EquipDefence += E_defence;
    }

    public void ShowInfo()
    {
        Console.WriteLine("Lv : {0}", Level);
        Console.WriteLine("Chad : {0}", Job);
        Console.Write("공격력 : {0}", Attack + EquipAttack);
        Console.WriteLine(" (+{0})", EquipAttack);
        Console.Write("방어력 : {0}", Defence + EquipDefence);
        Console.WriteLine(" (+{0})", EquipDefence);
        Console.WriteLine("체력 : {0}", Health);
        Console.WriteLine("Gold : {0}", Gold);
    }

}