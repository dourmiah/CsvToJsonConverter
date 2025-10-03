
namespace CsvToJsonConverter.Converter
{
    public abstract class Creator
    {
        public abstract IFile Create(string[] content);

        public IFile ProcessFile(string[] content)
        {
            var file = Create(content);
            file.Convert();
            return file;
        }
    }
}
