<template>
    <div>
        <h1 class="text-2xl font-bold">My Notes</h1>
        <ul>
            <li v-for="note in notes" :key="note.id" class="p-3 border-b">
            {{ note.title }} ({{ note.createdAt }})</li>
        </ul>
    </div>
</template>
<script setup>
    import { onMounted, ref } from 'vue';
    import { getNotes } from '@/services/noteService';
    const notes=ref([]);
    onMounted(async()=>{
        notes.value=await getNotes();
    })
</script>