<script setup lang="ts">
import { ref } from "vue";
import { createNote } from "@/services/noteService";
import router from "@/router/router";

const title = ref("");
const content = ref("");
const emit = defineEmits(["noteCreated"]);

const submitNote = async () => {
  if (!title.value.trim()) {
    alert("Title is required!");
    return;
  }

  const newNote = {
    Title: title.value,
    Content: content.value,
  };

  const createdNote = await createNote(newNote);
  
  if (createdNote) {
    router.push("/");
    title.value = "";
    content.value = "";
  }
};
</script>

<template>
  <div><RouterLink :to="`/`">Lists</RouterLink> | Create</div>
  <div class="h-full flex  bg-blue-100 p-4">
    <div class="w-full max-w-2xl mx-auto p-4 bg-white shadow-lg rounded-lg ">
    <h2 class="text-xl font-bold mb-2">Create a Note</h2>
    <form @submit.prevent="submitNote" class="flex flex-col gap-3 min-w-full">
      <input
        v-model="title"
        type="text"
        placeholder="Title"
        class="border p-2 rounded w-full"
        required
      />
      <textarea
        v-model="content"
        placeholder="Content (optional)"
        class="border p-2 rounded w-full"
      ></textarea>
      <button type="submit" class="bg-blue-500 text-white p-2 rounded hover:bg-blue-600">
        Add Note
      </button>
    </form>
  </div>
  </div>
</template>
