<script setup>
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState.js';
import RecipeModalContent from './RecipeModalContent.vue';
import { Modal } from 'bootstrap';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';


const activeRecipe = computed(() => AppState.activeRecipe)
const account = computed(() => AppState.account)
const viewingMode = computed(() => AppState.viewingMode)

async function changeViewMode(mode) {
    try {
        console.log('changing view mode to editing')
        recipesService.changeViewMode(mode)
    }
    catch (error) {
        Pop.error(error);
    }
}


onUnmounted(() => {
    Modal.getOrCreateInstance('#recipeModal').hide()
})
</script>


<template>
    <!-- Modal -->
    <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">

                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="recipeModalLabel">Modal title</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body " v-if="AppState.activeRecipe">
                    <slot></slot>
                </div>

                <div class="modal-footer" v-if="AppState.activeRecipe && account && AppState.viewingMode == 'viewing'">
                    <div>
                        <button type="button" class="btn btn-danger"><i class="mdi mdi-heart"></i></button>
                    </div>
                    <div v-if="activeRecipe.creatorId == account?.id">
                        <button @click="changeViewMode('editing')" type="button" class="btn btn-success">Edit
                            Recipe</button>
                        <button type="button" class="btn btn-danger">Delete Recipe</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>