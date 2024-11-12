using System.IO;
using Microsoft.AspNetCore.Mvc;
using myModels;

namespace fileService {
    public interface IfileService<T>
    {
    string FileName { get; set; }
    void WriteMessage(string message);
    void Write<T>(T data);
    void WriteLog(string m);
    List<T> Read<T>();
    void DeleteAllLines<T>();
    void Update<T>(List<T> list);
    }
}
