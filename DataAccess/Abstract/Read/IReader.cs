namespace DataAccess.Abstract.ReadAndWrite;

public interface IReader
{
    /*  IEnumerable<T> Read<T>(string x = null);*/
    IList<T> Read<T>();
}