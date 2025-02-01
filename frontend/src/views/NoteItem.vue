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
  <div><RouterLink :to="`/`">Lists</RouterLink> | Details</div>
  <div class="h-full flex  bg-blue-100 p-4">
    <div class="w-full max-w-2xl mx-auto p-4 bg-white shadow-lg rounded-lg">
    <div v-if="note" class="bg-white">
      <h2 class="text-xl font-semibold">{{ note.title }}</h2>
      <p class="text-gray-700 mt-2">{{ note.content }}</p>
      <p class="text-sm text-gray-500 mt-4">Created: {{ new Date(note.createdAt).toLocaleString() }}</p>
      <p class="text-sm text-gray-500">Last Updated: {{ new Date(note.updatedAt).toLocaleString() }}</p>
    </div>
    </div>
  </div>
</template>
