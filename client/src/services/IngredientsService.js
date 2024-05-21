import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { api } from "./AxiosService.js"

class IngredientsService{
    async postIngredient(ingredientData) {
        ingredientData.recipeId = AppState.activeRecipe.id
        const ingredient = {
            name: ingredientData.name,
            quantity: ingredientData.quantity,
            recipeId: ingredientData.recipeId
        }
        console.log('ingredient data:', ingredient)
        const response = await api.post(`api/ingredients`, ingredient)
        console.log('ingredient post response', response.data)
        const newIngredient = new Ingredient(response.data)
        AppState.activeIngredients.push(newIngredient)
    }
    
    async getActiveIngredients(recipeId){
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        console.log('ingredients response',response.data)
        AppState.activeIngredients = response.data.map(ingredient => new Ingredient(ingredient))
    }
    async deleteIngredient(ingredientId) {
        const response = await api.delete(`api/ingredients/${ingredientId}`)
        console.log('delete ingredient response:',response.data)
        const indexToDelete = AppState.activeIngredients.findIndex(ingredient=> ingredient.id == ingredientId)
        AppState.activeIngredients.splice(indexToDelete, 1)
    }
}

export const ingredientsService = new IngredientsService()