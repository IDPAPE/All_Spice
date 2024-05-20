<script setup>
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState.js';
import RecipeModalContent from './RecipeModalContent.vue';
import { Modal } from 'bootstrap';


const activeRecipe = computed(() => AppState.activeRecipe)

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
                    <RecipeModalContent />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>