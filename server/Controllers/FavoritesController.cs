using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace All_Spice.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class FavoritesController : ControllerBase
{

    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0Provider;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _favoritesService = favoritesService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<FavoriteRecipe>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.CreatorId = userInfo.Id;
            FavoriteRecipe favorite = _favoritesService.CreateFavorite(favoriteData);
            return Ok(favorite);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}