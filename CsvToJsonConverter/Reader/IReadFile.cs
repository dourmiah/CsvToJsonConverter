
namespace CsvToJsonConverter.Reader
{
    public interface IFileReader
    {
        string[] Read(string path);
    }
}
