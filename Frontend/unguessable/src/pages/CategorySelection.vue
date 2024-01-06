<script setup lang="ts">
import { Ref, computed, ref } from 'vue';
import { useRouter } from 'vue-router'
import {Category} from '../classes/Category.ts';
import GameCategory from '../components/GameCategory.vue';
const fetchedCategories:Ref<Category[]>=ref([]);

const selectedCategories:Ref<number[]>=ref([]);
    const router = useRouter()
    const isvisible = computed(() => {
  return selectedCategories.value.length > 0 ? "visible" : "hidden"
})

function OK(value:boolean,id:number)
{
console.log(value + " "+id );
if(value)
{
    selectedCategories.value.push(id);
}
else{
    selectedCategories.value= selectedCategories.value.filter(num => num !== id);
}
console.log(selectedCategories.value);
}

function StartGame()
{  
  try {
    document.documentElement.requestFullscreen();
}
catch(err) {
console.error(err);
}
 

    
router.push({name:'Play', params: { categories:  JSON.stringify(selectedCategories.value) } });
}




</script>
<template>
    <div class="container" >
    
      <h3 class="mt-3 ">Kategorien</h3>  
      <div class="row">
        <div class="col-4 mt-2" v-for="item in fetchedCategories">
<GameCategory @selectionChanged="OK" v-bind:CategoryID="item.ID" v-bind:title="item.title" v-bind:ImageURL="item.ImageURL" />
</div>
</div>
  <!-- Sticky bottom button -->
  <span @click="StartGame" type="button" class="sticky-bottom-button isVisible">
    <lottie-player style="width: 700px; height: 700px"   src="/playbutton.json" background="transparent" speed="1" direction="1" mode="normal" loop  autoplay></lottie-player>
  </span>

</div>
</template>

<style>


.sticky-bottom-button {
      position: fixed;
      bottom: 20px; /* Adjust this value to set the distance from the bottom */
      right: 20px; /* Adjust this value to set the distance from the right */
      z-index: 1000;
      width: 60px;
      height: 60px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
  
    }

.isVisible
{
  visibility: v-bind('isvisible');
}
  

</style>