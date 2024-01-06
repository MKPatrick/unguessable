<script setup lang="ts">
import { ref } from 'vue';


const isSelected=ref(false);
const fontweight=ref(200);
const props = defineProps({
  CategoryID:Number,
  title: String,
  ImageURL: String
})

const emit = defineEmits<{
  (e: 'selectionChanged', value: boolean, id:number ): void
}>()


function OnCheckButton()
{

  isSelected.value=!isSelected.value;
  if(isSelected.value)
  fontweight.value=450;
else
fontweight.value=200;
  emit("selectionChanged",isSelected.value,props.CategoryID!);
}

</script>
<template>
<div @click="OnCheckButton" class="card shadow-lg">
  <div class="selectedplaceholder" >
    <span  v-if="isSelected">✅</span>
  </div>

<img   :src="ImageURL" class="img-card" />
<p class="text-center headline mt-1">

<span>  {{ title }} </span>

</p>
</div>
</template>

<style >


.img-card {
      width: 100%;
    object-fit: cover;
    }



.card
{
  background-color: #272C3A;
  border-radius: 5px;

font-size: small;
  width: 100%;
}

    /* Make sure the image inside the card body takes up 100% of the height */
.selectedplaceholder
{
  position: absolute;
  z-index: 100;
  display:inline;
  height: 12px;
}

.headline
{
  position: absolute;
  bottom: 0;
  margin: auto;
  text-align: center;
  width: 100%;
  font-weight: v-bind('fontweight');
}


</style>