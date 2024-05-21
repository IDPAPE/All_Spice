<script setup>
import { computed, ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { ingredientsService } from '../services/IngredientsService.js';

const activeRecipe = computed(() => AppState.activeRecipe)
const activeIngredients = computed(() => AppState.activeIngredients)
const ingredientFormData = ref({
    name: '',
    quantity: '',
})
const recipeFormData = ref({
    title: `${activeRecipe.value.title}`,
    instructions: `${activeRecipe.value.instructions}`
})

async function changeViewMode(mode) {
    try {
        console.log('changing view mode to editing')
        recipesService.changeViewMode(mode)
    }
    catch (error) {
        Pop.error(error);
    }
}

async function updateRecipe() {
    try {
        await recipesService.updateRecipe(recipeFormData.value)
        Pop.success('updated successfully')
    }
    catch (error) {
        Pop.error(error);
    }
}

async function postIngredient() {
    try {
        await ingredientsService.postIngredient(ingredientFormData.value)
        ingredientFormData.value = { name: '', quantity: '' }
    }
    catch (error) {
        Pop.error(error);
    }
}

async function deleteIngredient(ingredientId) {
    try {
        await ingredientsService.deleteIngredient(ingredientId)
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
                <img :src="activeRecipe.img" alt="" class="img">
            </div>
            <div class="col-8">
                <section class="row">
                    <div class="col">
                        <h2>
                            <input v-model="recipeFormData.title" type="text" class="w-75"> <button
                                class="btn btn-primary rounded-pill ms-2">{{
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
                            <div class="col text-end">
                                <form @submit.prevent="updateRecipe()">
                                    <textarea v-model="recipeFormData.instructions" name="instructions"
                                        id="instructions" rows="15" class="w-100"
                                        :placeholder="activeRecipe.instructions"></textarea>
                                    <!-- {{ activeRecipe.instructions }} -->
                                    <button type="submit" class="btn btn-success mb-2">Save Instructions</button>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col border border-warning rounded ms-2">
                        <div class="row">
                            <h3>Ingredients</h3>
                        </div>
                        <div v-if="activeIngredients" class="container-fluid">
                            <div class="row" v-for="ingredient in activeIngredients" :key="ingredient.id">
                                <div class="col">
                                    <!-- <span class="fw-bold">{{ ingredient.index }}.</span> -->
                                    <span @click="deleteIngredient(ingredient.id)" class="ms-1 selectable text-danger"
                                        role="button"><i class="mdi mdi-close"></i></span>
                                    <span class="ms-1">{{ ingredient.quantity }}:</span>
                                    <span class="ms-1">{{ ingredient.name }}</span>
                                    <hr class="m-0 mb-1" />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-2">
                            <form @submit.prevent="postIngredient()">
                                <div class="input-group">
                                    <div class="form-floating">
                                        <input v-model="ingredientFormData.quantity" type="text" aria-label="Quantity"
                                            id="quantity" class="form-control border border-dark" required minlength="1"
                                            maxlength="50">
                                        <label for="quantity">Quantity</label>
                                    </div>
                                    <div class="form-floating">
                                        <input v-model="ingredientFormData.name" type="text" aria-label="Ingredient"
                                            id="ingredient" class="form-control border border-dark" required
                                            minlength="2" maxlength="50">
                                        <label for="ingredient">Ingredient</label>
                                    </div>
                                    <button class="btn btn-success text-dark btn-outline-dark" type="submit"
                                        id="button-addon2"><i class="mdi mdi-plus"></i></button>
                                </div>
                            </form>
                        </div>
                    </div>
                </section>
            </div>
        </section>
        <!-- <hr /> -->
    </div>
    <div class="modal-footer pb-0 mt-4">
        <button @click="changeViewMode('viewing')" class="btn btn-primary">Done Editing</button>
    </div>
</template>


<style lang="scss" scoped>
.img {
    height: 50dvh;
    width: 100%;
    object-fit: cover;
    object-position: center;
}
</style>