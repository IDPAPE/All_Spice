import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { api } from "./AxiosService.js"

class IngredientsService{

    async getActiveIngredients(recipeId){
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        console.log('ingredients response',response.data)
        AppState.activeIngredients = response.data.map(ingredient => new Ingredient(ingredient))
    }
}

export const ingredientsService = new IngredientsService()