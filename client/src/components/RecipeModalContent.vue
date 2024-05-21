<script setup>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';

const activeRecipe = computed(() => AppState.activeRecipe)
const activeIngredients = computed(() => AppState.activeIngredients)

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
                        <h2>{{ activeRecipe.title }}<button class="btn btn-primary rounded-pill ms-2">{{
                            activeRecipe.category
                                }}</button>
                        </h2>
                    </div>
                </section>
                <section class="row">
                    <div class="col border rounded me-2">
                        <div class="row">
                            <h3>Recipe Instructions</h3>
                        </div>
                        <div class="row">
                            <div class="col">
                                {{ activeRecipe.instructions }}
                            </div>
                        </div>
                    </div>
                    <div class="col border rounded ms-2">
                        <div class="row">
                            <h3>Ingredients</h3>
                        </div>
                        <div v-if="activeIngredients" class="container-fluid">
                            <div class="row" v-for="ingredient in activeIngredients" :key="ingredient.id">
                                <div class="col">
                                    <!-- <span class="fw-bold">{{ ingredient.index }}.</span> -->
                                    <span class="ms-1">{{ ingredient.quantity }}:</span>
                                    <span class="ms-1">{{ ingredient.name }}</span>
                                    <hr class="m-0 mb-1" />
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
    height: 50dvh;
    width: 100%;
    object-fit: cover;
    object-position: center;
}
</style>