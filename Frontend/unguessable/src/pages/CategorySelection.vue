<script setup lang="ts">
import { Ref, computed, onMounted, ref } from 'vue';
import { useRouter } from 'vue-router'
import axios from 'axios'
import {Category} from '../classes/Category.ts';
import GameCategory from '../components/GameCategory.vue';
const fetchedCategories:Ref<Category[]>=ref([]);

const selectedCategories:Ref<number[]>=ref([]);
    const router = useRouter()
    const isvisible = computed(() => {
  return selectedCategories.value.length > 0 ? "visible" : "hidden"
})

function SelectionChanged(value:boolean,id:number)
{

if(value)
{
    selectedCategories.value.push(id);
    localStorage.selectedCategories=JSON.stringify(selectedCategories.value);
}
else{

    selectedCategories.value= selectedCategories.value.filter(num => num !== id);
    localStorage.selectedCategories=JSON.stringify(selectedCategories.value);
}

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


onMounted(()=>
{
  axios.get('https://backend.unguessable.appgrove.xyz/api/Categories').then((resp)=>
  {
    const data:Array<Category>=resp.data;
      fetchedCategories.value=data;
      if(localStorage.selectedCategories)
      {
        
        let numberArray = JSON.parse(localStorage.selectedCategories);
        numberArray.forEach((val:number)=>{
          selectedCategories.value.push(val);
        });
      
        fetchedCategories.value.forEach((val:Category)=>
        {
     let oldCategories:number[]=   JSON.parse(localStorage.selectedCategories);
   
  if(oldCategories.indexOf(val.id)!=-1)
{
console.log(val.id);
console.log(oldCategories);
  val.selected=true;
}

        });
      }
  });
});

</script>
<template>
    <div class="container mb-3" >
    
      <h3 class="mt-3">Kategorien</h3>  
      <div class="row">
        <div class="col-4 mt-2 category" v-for="item in fetchedCategories">
<GameCategory v-bind:selected="item.selected" @selectionChanged="SelectionChanged" v-bind:CategoryID="item.id" v-bind:title="item.title" v-bind:ImageURL="item.imageUrl" />
</div>
</div>
  <!-- Sticky bottom button -->
  <span @click="StartGame" type="button" class="sticky-bottom-button isVisible">
    <lottie-player  src="/playbutton.json" background="transparent" speed="1" direction="1" mode="normal" loop  autoplay></lottie-player>
  </span>

</div>
</template>

<style >
.category{

  font-family: 'Pacifico', cursive;
  text-shadow: 1px 0 0 #000, 0 -1px 0 #000, 0 1px 0 #000, -1px 0 0 #000;

}

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