import { api } from "./AxiosService.js"

class RecipesService{

    async getAllRecipes(){
        const response = await api.get('api/recipes')
        console.log('recipes response', response.data)
    }
}

export const recipesService = new RecipesService