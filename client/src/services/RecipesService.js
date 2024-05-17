import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService{
    showMyFavorites() {
      if(AppState.account != null){
        AppState.activeRecipes = AppState.myFavoriteRecipes
      }
    }
    showMyRecipes() {
    if(AppState.account != null)
        {
      const myRecipes = AppState.allRecipes.filter(recipe => recipe.creatorId == AppState.account.id)
      AppState.activeRecipes = myRecipes
        }
    }
    showAllRecipes() {
        AppState.activeRecipes = AppState.allRecipes
    }

    async getAllRecipes(){
        const response = await api.get('api/recipes')
        const recipes = response.data.map(recipe => new Recipe(recipe))
        AppState.allRecipes = recipes
        AppState.activeRecipes = recipes
        console.log('Appstate recipes', AppState.allRecipes)
    }
}

export const recipesService = new RecipesService