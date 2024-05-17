import { AppState } from "../AppState.js";
import { FavoriteRecipe } from "../models/FavoriteRecipe.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";

class FavoritesService{

    async getMyFavorites(){
        // console.log('account:', AppState.account)
        const response = await api.get('account/favorites')
        //FIXME - this might need to change later
        const myFavorites = response.data.map(favoriteRecipe => new Recipe(favoriteRecipe))
        AppState.myFavoriteRecipes = myFavorites
        console.log(AppState.myFavoriteRecipes)
    }
}
export const favoritesService = new FavoritesService();