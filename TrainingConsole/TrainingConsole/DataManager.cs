using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TrainingConsole;

public class Data
{
    [JsonPropertyName("_player")]
    public Warrior _player { get; set; }
    [JsonPropertyName("_Item")]
    public List<Item> _Item { get; set; }
}


public class DataManager
{
    public void Save(string saveFile, Data data)
    {
        try
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(saveFile, json);
            Console.WriteLine("저장완료");
            Thread.Sleep(1000);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving data: {e.Message}");
        }
       
    }

    public Data Load(string saveFile)
    {
        string json = File.ReadAllText(saveFile);
        Console.WriteLine("로드완료");
        Thread.Sleep(1000);
        return JsonConvert.DeserializeObject<Data>(json);
       
    }
}