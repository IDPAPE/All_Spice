<script setup>
import { computed } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

const activeRecipe = computed(() => AppState.activeRecipe)
const activeIngredients = computed(() => AppState.activeIngredients)

async function changeViewMode(mode) {
    try {
        console.log('changing view mode to editing')
        recipesService.changeViewMode(mode)
    }
    catch (error) {
        Pop.error(error);
    }
}
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
                    <div class="col border border-warning rounded me-2">
                        <div class="row">
                            <h3>Recipe Instructions</h3>
                        </div>
                        <div class="row">
                            <div class="col">
                                <textarea name="instructions" id="instructions" rows="15" class="w-100"
                                    :placeholder="activeRecipe.instructions"></textarea>
                                <!-- {{ activeRecipe.instructions }} -->
                            </div>
                        </div>
                    </div>
                    <div class="col border border-warning rounded ms-2">
                        <div class="row">
                            <h3>Ingredients</h3>
                        </div>
                        <div class="row" v-if="activeIngredients">
                            <div class="col" v-for="ingredient in activeIngredients" :key="ingredient.id">
                                <div>
                                    <span class="fw-bold">{{ ingredient.id }}.</span>
                                    <span class="ms-1">{{ ingredient.quantity }}</span>
                                    <span class="ms-1">{{ ingredient.name }}</span>
                                    <hr class="m-0 mb-1" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-group">
                                <div class="form-floating">
                                    <input type="text" aria-label="Quantity" id="quantity"
                                        class="form-control border border-dark">
                                    <label for="quantity">Quantity</label>
                                </div>
                                <div class="form-floating">
                                    <input type="text" aria-label="Ingredient" id="ingredient"
                                        class="form-control border border-dark">
                                    <label for="ingredient">Ingredient</label>
                                </div>
                                <button class="btn btn-success text-light btn-outline-dark" type="button"
                                    id="button-addon2"><i class="mdi mdi-plus"></i></button>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>
        <hr />
    </div>
    <div class="modal-footer pb-0">
        <button @click="changeViewMode('viewing')" class="btn btn-primary">Done Editing</button>
    </div>
</template>


<style lang="scss" scoped></style>