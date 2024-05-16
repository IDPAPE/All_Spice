


namespace All_Spice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }


    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repository.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"could not find recipe with id: {recipeId}");
        }
        return recipe;

    }

    internal Recipe UpdateRecipe(Recipe recipeData, int recipeId, string userId)
    {
        Recipe recipeToUpdate = _repository.GetRecipeById(recipeId);
        if (recipeToUpdate.CreatorId != userId)
        {
            throw new Exception($"cannot update recipe with id: {recipeToUpdate.Id}, not yours");
        }
        recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
        recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;
        recipeToUpdate.Img = recipeData.Img ?? recipeToUpdate.Img;
        recipeToUpdate.Category = recipeData.Category ?? recipeToUpdate.Category;

        Recipe updatedRecipe = _repository.UpdateRecipe(recipeToUpdate);
        return updatedRecipe;
    }

    internal string DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipeToDelete = GetRecipeById(recipeId);
        if (recipeToDelete.CreatorId != userId)
        {
            throw new Exception($"cannot delete recipe with id: {recipeToDelete.Id}, not yours");
        }
        string Message = _repository.DeleteRecipe(recipeToDelete);
        return Message;
    }
}