


namespace All_Spice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal Favorite GetFavoriteRecipeById(int favoriteId)
    {
        Favorite favorite = _repository.GetMyFavoriteRecipesById(favoriteId);
        if (favorite == null)
        {
            throw new Exception($"could not find recipe with Id: {favoriteId}");
        }
        return favorite;
    }
    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteRecipe favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }

    internal List<FavoriteRecipe> GetMyFavoriteRecipes(string userId)
    {
        List<FavoriteRecipe> myFavorites = _repository.GetMyFavoriteRecipes(userId);
        return myFavorites;
    }
    internal string DeleteFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteRecipeById(favoriteId);
        if (favorite.CreatorId != userId)
        {
            throw new Exception($"cannot delete favorite with id {favoriteId} not yours");
        }
        _repository.DeleteFavorite(favoriteId);
        return $"favorite with Id {favoriteId} was deleted";
    }
}