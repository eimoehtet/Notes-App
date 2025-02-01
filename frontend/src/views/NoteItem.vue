<script setup lang="ts">
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import { deleteNote } from "@/services/noteService";
import router from "@/router/router";
import { getNoteById } from "@/services/noteService";

const route = useRoute();
const noteId = route.params.id;
const note = ref(null);



const fetchNote = async()=>{
  note.value=await getNoteById(Number(noteId));
}

onMounted(fetchNote);
</script>

<template>
  <div class="max-w-2xl mx-auto p-6 bg-gray-100 shadow-lg rounded-lg">
    <h1 class="text-2xl font-bold mb-4">Note Details</h1>
    <div v-if="note">
      <h2 class="text-xl font-semibold">{{ note.title }}</h2>
      <p class="text-gray-700 mt-2">{{ note.content }}</p>
      <p class="text-sm text-gray-500 mt-4">Created: {{ new Date(note.createdAt).toLocaleString() }}</p>
      <p class="text-sm text-gray-500">Last Updated: {{ new Date(note.updatedAt).toLocaleString() }}</p>
    </div>
    
    
  </div>
</template>
