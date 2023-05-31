using DataAccess.Abstract.ReadAndWrite;
using Newtonsoft.Json;

namespace DataAccess.Concrete.Reader;

public class JsonReader : IReader
{
    static readonly object _fileLock = new();
    readonly string _filePath;

    public JsonReader(string filePath)
    {
        _filePath = filePath;
    }

    public IList<T> Read<T>()
    {
        lock (_fileLock)
        {
            using (var reader = new StreamReader(_filePath))
            {
                var json = reader.ReadToEnd();
                var entries = JsonConvert.DeserializeObject<List<T>>(json);
                return entries;
            }
        }
    }


    public IEnumerable<T> Read<T>(string x = null)
    {
        lock (_fileLock)
        {
            using (var reader = new StreamReader(_filePath))
            {
                var json = reader.ReadToEnd();
                var entries = JsonConvert.DeserializeObject<List<T>>(json);
                foreach (var entry in entries) yield return entry;
            }
        }
    }
}