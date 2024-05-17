<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';


const activeRecipe = computed(() => AppState.activeRecipe)
</script>


<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-4">
                <img class="img" :src="activeRecipe.img" alt="">
            </div>
            <div class="col-4">
                qpowe
            </div>
            <div class="col-4">
                zxopvi
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.img {
    object-fit: contain;
}
</style>