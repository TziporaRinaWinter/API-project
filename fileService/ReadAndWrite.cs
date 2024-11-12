using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace fileService{
    public class ReadAndWrite<T> : IfileService<T>
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
        
    public ReadAndWrite()
    {
        this.FilePath = Path.Combine(Environment.CurrentDirectory, "File");
    }

    public void WriteMessage(string message)
    {

        if (File.Exists(Path.Combine(FilePath,FileName)))
        {
            File.WriteAllText(Path.Combine(FilePath, FileName), $"{message}\n");
        }
    }
    public void WriteLog(string message)
    {
        // if (File.Exists(Path.Combine(FilePath,FileName)))
        // {
            File.AppendAllText(Path.Combine(FilePath, FileName), $"{message}\n");
        // }
    }

    public void Write<T>(T data)
    {
        string json = File.ReadAllText(Path.Combine(FilePath, FileName));
        var TList = JsonSerializer.Deserialize<List<T>>(json);
        TList.Add(data);
        json = JsonSerializer.Serialize(TList);
        WriteMessage(json);
    }
    public List<T> Read<T>()
    {
        string json = File.ReadAllText(Path.Combine(FilePath, FileName));
        var TList = JsonSerializer.Deserialize<List<T>>(json);
        if (TList != null)
            return TList;
        return default(List<T>);
    }
    public void DeleteAllLines<T>(){
        if(File.Exists(Path.Combine(FilePath, FileName))){
            File.Delete(Path.Combine(FilePath, FileName));
            File.AppendAllText(Path.Combine(FilePath, FileName),"\n");
        }
    }
    public void Update<T>(List<T> list)
    {
        string json = JsonSerializer.Serialize(list);
        WriteMessage(json);
    }
}
}
