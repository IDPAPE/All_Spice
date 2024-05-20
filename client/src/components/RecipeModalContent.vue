<script setup>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import Pop from '../utils/Pop.js';
import { ingredientsService } from '../services/IngredientsService.js';


const activeRecipe = computed(() => AppState.activeRecipe)
const activeIngredients = computed(() => AppState.activeIngredients)

async function getActiveIngredients() {
    try {
        ingredientsService.getActiveIngredients()
    }
    catch (error) {
        Pop.error(error);
    }
}

onMounted(() => {
    getActiveIngredients()
})
</script>


<template>
    <div class="container-fluid">
        <section class="row">
            <div class="col-4">
                <img :src="activeRecipe.img" alt="" class="w-100">
            </div>
            <div class="col-8">
                <section class="row">
                    <div class="col">
                        <h2>{{ activeRecipe.title }}<button class="btn btn-primary rounded-pill ms-2">{{
                            activeRecipe.category
                                }}</button>
                        </h2>
                    </div>
                </section>
                <section class="row">
                    <div class="col-6">
                        <div class="row">
                            <h3>Recipe Instructions</h3>
                        </div>
                        <div class="row">
                            <div class="col">
                                {{ activeRecipe.instructions }}
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="row">
                            <h3>Ingredients</h3>
                        </div>
                        <div class="row" v-if="activeIngredients">
                            <div class="col" v-for="ingredient in activeIngredients" :key="ingredient.id">
                                <div>
                                    <span class="fw-bold">{{ ingredient.id }}.</span>
                                    <span class="ms-1">{{ ingredient.quantity }}</span>
                                    <span class="ms-1">{{ ingredient.name }}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>
    </div>
</template>


<style lang="scss" scoped>
.img {
    object-fit: contain;
}
</style>