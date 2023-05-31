using System.Reflection;
using Utilities.CustomAttribute;

namespace DataAccess;

[String("singleton Paths")]
public class Paths
{
    static readonly Lazy<Paths> _instance = new(() => new Paths());

    readonly string _customPathDirectory;

    public Paths()
    {
        _customPathDirectory = GetSortingPatternDirectory();
        BoolSample = GetFilePath("boolsample.json");
        LongSample = GetFilePath("longsample.json");
        StringSample = GetFilePath("stringsample.json");
    }

    public static Paths Instance => _instance.Value;

    public string BoolSample { get; }
    public string LongSample { get; }
    public string StringSample { get; }


    string GetSortingPatternDirectory()
    {
        var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var basePath = Path.Combine(assemblyDirectory, "..\\..\\..\\..\\DataAccess\\Constants\\");
        return Path.GetFullPath(basePath);
    }

    string GetFilePath(string fileName)
    {
        return Path.Combine(_customPathDirectory, fileName);
    }
}