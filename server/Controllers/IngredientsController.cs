namespace All_Spice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController
{

    private readonly IngredientsService _ingredientsService;

    public IngredientsController(IngredientsService ingredientsService)
    {
        _ingredientsService = ingredientsService;
    }
}