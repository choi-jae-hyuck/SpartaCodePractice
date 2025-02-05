using Newtonsoft.Json;

namespace TrainingConsole;

public class Data
{
    public Warrior _player { get; set; }
    public List<Item> _Item { get; set; }
}


public class DataManager
{
    public void Save(string saveFile, Data data)
    {
        try
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(saveFile, json);
            Console.WriteLine("저장완료");
            Thread.Sleep(1000);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving data: {e.Message}");
        }
       
    }

    public void Load(string saveFile, Data data)
    {
        string json = File.ReadAllText(saveFile);
        data = JsonConvert.DeserializeObject<Data>(json);
        Console.WriteLine("로드완료");
        Thread.Sleep(1000);
    }
}