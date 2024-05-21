import { reactive } from 'vue'
import { Recipe } from './models/Recipe.js'
import { FavoriteRecipe } from './models/FavoriteRecipe.js'
import { Ingredient } from './models/Ingredient.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,

  /** @type {Recipe[]} */
  allRecipes: [],

  /** @type {Recipe[]} */
  activeRecipes: [],

  /** @type {FavoriteRecipe[]} */
  myFavoriteRecipes: [],

  /** @type {Recipe} */
  activeRecipe: null,

  /** @type {Ingredient[]} */
  activeIngredients: [],

  /**@type {string} */
  viewingMode: 'viewing',
})