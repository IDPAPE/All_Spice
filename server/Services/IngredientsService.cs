


namespace All_Spice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
    {
        _repository = repository;
        _recipesService = recipesService;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repository.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _repository.GetIngredientById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception($"could not find ingredient with id: {ingredientId}");
        }
        return ingredient;
    }
    internal string DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = GetIngredientById(ingredientId);
        Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception($"You cannot delete this ingredient, you do not own the recipe");
        }
        _repository.DeleteIngredient(ingredientId);
        return $"{ingredient.Name} was removed successfuly from {recipe.Title}";
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
}