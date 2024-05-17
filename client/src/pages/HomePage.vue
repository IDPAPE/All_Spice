<script setup>
import { onMounted } from 'vue';
import RecipeCard from '../components/RecipeCard.vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';

async function getAllRecipes() {
  try {
    await recipesService.getAllRecipes()
  }
  catch (error) {
    Pop.toast('could not get all recipes', 'error')
    console.error(error)
  }
}

onMounted(() => {
  getAllRecipes()
})
</script>

<template>
  <div class="container-fluid">
    <div class="row bg-primary justify-content-center m-2 hero-img rounded">
      <div class="col-md-4 col-10 d-flex flex-column text-center m-3 justify-content-center">
        <div>
          <h1>All-Spice</h1>
          <p>Come get yer fixins</p>
        </div>
      </div>
    </div>

    <div class="row justify-content-center floating-buttons ">
      <div class="selectable rounded-start col-md-2 col-4 border border-dark border-end-0 text-center p-2 bg-white">
        <h5>All Recipes</h5>
      </div>
      <div class="selectable col-md-2 col-4 border border-dark border-start-0 border-end-0 text-center p-2 bg-white">
        <h5>My Recipes</h5>
      </div>
      <div class="selectable rounded-end col-md-2 col-4 border border-dark border-start-0 text-center p-2 bg-white">
        <h5>My Favorites</h5>
      </div>
    </div>

    <div class="row px-2">
      <div class="col-3 p-2">
        <RecipeCard />
      </div>
      <div class="col-3 p-2">
        <RecipeCard />
      </div>
      <div class="col-3 p-2">
        <RecipeCard />
      </div>
      <div class="col-3 p-2">
        <RecipeCard />
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.hero-img {
  height: 20dvh;
}

.floating-buttons {
  transform: translate(0dvh, -4dvh);
}
</style>
