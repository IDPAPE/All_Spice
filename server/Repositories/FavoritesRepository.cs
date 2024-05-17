



namespace All_Spice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite PopulateCreator(Favorite favorite, Profile profile)
    {
        favorite.Creator = profile;
        return favorite;
    }

    internal Favorite GetMyFavoriteRecipesById(int favoriteId)
    {
        string sql = @"
        SELECT * FROM favorites WHERE id = @favoriteId;
        ";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }
    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
            INSERT INTO 
            favorites(
                recipeId,
                creatorId
            )
            VALUES(
                @RecipeId,
                @CreatorId
            );
            SELECT
            favorites.*, 
            recipes.*,
            accounts.* 
            FROM favorites
            JOIN recipes ON favorites.recipeId = recipes.id
            JOIN accounts ON favorites.creatorId = accounts.id
            WHERE favorites.id = LAST_INSERT_ID();
        ";

        FavoriteRecipe favorite = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.CreatorId = favorite.CreatorId;
            recipe.Creator = profile;
            return recipe;
        }, favoriteData).FirstOrDefault();
        return favorite;
    }

    internal List<FavoriteRecipe> GetMyFavoriteRecipes(string userId)
    {
        string sql = @"
            SELECT
            favorites.*, 
            recipes.*,
            accounts.* 
            FROM favorites
            JOIN recipes ON favorites.recipeId = recipes.id
            JOIN accounts ON favorites.creatorId = accounts.id
            WHERE favorites.creatorId = @userId;";

        List<FavoriteRecipe> myFavorites = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.CreatorId = favorite.CreatorId;
            recipe.Creator = profile;
            return recipe;
        }, new { userId }).ToList();
        return myFavorites;
    }

    internal void DeleteFavorite(int favoriteId)
    {
        string sql = @"DELETE FROM favorites WHERE favorites.id = @favoriteId;";

        _db.Execute(sql, new { favoriteId });
    }
}