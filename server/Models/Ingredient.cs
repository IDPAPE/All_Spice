namespace All_Spice.Models;

public class Ingredient
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string quantity { get; set; }
    public int RecipeId { get; set; }
}