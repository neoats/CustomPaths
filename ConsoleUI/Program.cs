using ConsoleUI.Models;
using DataAccess;
using DataAccess.Concrete.Reader;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        var reader = new JsonReader(Paths.Instance.BoolSample);
        var jsonData = reader.Read<DataModel>();
        var dataList = jsonData.ToList();
        foreach (var data in dataList) Console.WriteLine(data.value + " " + data.BoolValue);
    }
}