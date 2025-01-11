namespace RecipeBook.DataAcces
{
    public interface IStringsRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }
}
