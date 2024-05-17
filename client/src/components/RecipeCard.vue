<script setup>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';


const props = defineProps({ recipe: { type: Recipe, required: true } })
const bgImg = computed(() => `url(${props.recipe.img})`)
</script>


<template>
    <div class="card bg-primary container-fluid d-flex text-light">
        <div class="row">
            <div class="col-5 bg-glass m-1 rounded text-center">
                <h5 class="">{{ recipe.category }}</h5>
            </div>
        </div>
        <div class="row flex-grow-1">

        </div>
        <div class="row ">
            <div class="col bg-glass m-1 rounded p-2">
                <h5 class="fw-bold m-0">
                    {{ recipe.title }}
                </h5>
                <h6 class="m-0">
                    {{ recipe.creator.name }}
                </h6>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.card {
    height: 25dvh;
    background-image: v-bind(bgImg);
    background-size: cover;
    background-position: center;
    filter: drop-shadow(0.75rem 0.75rem 0.75rem rgb(180, 173, 174));
}

.bg-glass {
    background-color: rgba(68, 68, 68, 0.9);
}
</style>