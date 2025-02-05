namespace TrainingConsole;


public class Sleep
{
    private int RESTHEALTH = 100;
    
    public void RestInfo(Warrior warrior)
    {
        int restGold = 500;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine("{0} G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {1} G)",restGold, warrior.Gold);
            Console.WriteLine("");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");

            Console.Write("원하시는 행동을 선택하십시오 : ");
            int playerAction = int.Parse(Console.ReadLine());

            switch (playerAction)
            {
                case 0 :
                    return;
                
                case 1 :
                    if (warrior.Gold >= restGold)
                    {
                        warrior.Gold -= restGold;
                        Console.WriteLine("휴식을 완료했습니다");
                        warrior.Health = RESTHEALTH;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다"); 
                    }
                    Thread.Sleep(1000);
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                    break;
            }

        }
    }
}