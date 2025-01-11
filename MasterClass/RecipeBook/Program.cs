using RecipeBook.App;
using RecipeBook.DataAcces;
using RecipeBook.FileAcces;
using RecipeBook.Recipes.Ingredients;
using RecipeBook.Recipes;

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

const string FileName = "recipes";
var fileMetadata = new FileMetaData(FileName, Format);

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister),
    new RecipesConsoleUserInteraction(
        ingredientsRegister));

cookiesRecipesApp.Run(fileMetadata.ToPath());