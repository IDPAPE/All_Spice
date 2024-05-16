
namespace All_Spice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteRecipe favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }
}