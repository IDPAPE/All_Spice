namespace All_Spice.Repositories;

public class IngredientsRepository
{

    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }
}