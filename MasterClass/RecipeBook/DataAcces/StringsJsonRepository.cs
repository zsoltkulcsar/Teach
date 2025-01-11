using System.Text.Json;

namespace RecipeBook.DataAcces
{
    public class StringsJsonRepository : StringsRepository
    {
        protected override string StringsToText(List<string> strings)
        {
            return JsonSerializer.Serialize(strings);
        }

        protected override List<string> TextToStrings(string fileContents)
        {
            return JsonSerializer.Deserialize<List<string>>(fileContents);
        }
    }
}
