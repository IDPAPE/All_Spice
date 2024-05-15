namespace All_Spice.Models;

public class Ingredient
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string name { get; set; }
    public string quantity { get; set; }
    public int recipeId { get; set; }
}