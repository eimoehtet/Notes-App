<script setup lang="ts">
import { ref,onMounted } from "vue";
import router from "@/router/router";
import { getNoteById, updateNote } from "@/services/noteService";
import { useRoute } from "vue-router";

const emit = defineEmits(["noteUpdated"]);
const route=useRoute();
const noteId=route.params.id;
const note = ref({
  id: 0, 
  title: "",
  content: "",
});


const fetchNote=async()=>{
  note.value=await getNoteById(Number(noteId));
}

onMounted(async()=>{
  
  note.value=await getNoteById(Number(noteId));
});

const saveNote=async()=>{

  const updatednote={
  id:noteId,  
  title:note.value.title,
  content:note.value.content
}
  console.log(updatednote);
  console.log(noteId);
  try{
    const res=await updateNote(Number(noteId),updatednote);
    alert("Updated successfully");
    router.push("/");
    //console.log(res);
  }catch(error){
    console.log(error);
  }
    
    
}
</script>

<template>
  <div><RouterLink :to="`/`">Lists</RouterLink> | Edit</div>
  <div class="h-full flex  bg-blue-100 p-4">
    <div class="w-full max-w-2xl mx-auto p-4 bg-white shadow-lg rounded-lg">
    <h2 class="text-xl font-bold mb-2">Update a Note</h2>
    <form @submit.prevent="saveNote" class="flex flex-col gap-3">
      <input
        v-if="note"
        v-model="note.title"
        id="title"
        type="text"
        placeholder="Title"
        class="border p-2 rounded w-full"
        required
      />
      <textarea
      v-if="note"
        v-model="note.content"
        id="content"
        placeholder="Content (optional)"
        class="border p-2 rounded w-full"
      ></textarea>
      <button type="submit" class="bg-blue-500 text-white p-2 rounded hover:bg-blue-600">
        Update Note
      </button>
    </form>
  </div>
  </div>
</template>
