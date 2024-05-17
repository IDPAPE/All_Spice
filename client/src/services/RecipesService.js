import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService{
    showAllRecipes() {
        AppState.activeRecipes = AppState.allRecipes
    }

    async getAllRecipes(){
        const response = await api.get('api/recipes')
        const recipes = response.data.map(recipe => new Recipe(recipe))
        AppState.allRecipes = recipes
        AppState.activeRecipes = recipes
    }
}

export const recipesService = new RecipesService