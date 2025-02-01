<script setup >
    import { onMounted, ref } from 'vue';
    import { getNotes } from '@/services/noteService';
    import { PencilIcon,EyeIcon,TrashIcon } from '@heroicons/vue/24/solid';
    import { deleteNote } from '@/services/noteService';
    import router from '@/router/router';

    const notes=ref([]);

    const GetNotes =async()=>{
       notes.value=await getNotes();
    }

    onMounted(async()=>{
        await GetNotes();
    })
    const deletenote = async(noteId)=>{
      console.log("Note ID:",noteId)
      await deleteNote(Number(noteId)); 
      alert("successfully delete");
      router.push("/");
      GetNotes();
}
</script>
<template>
  <div>Lists</div>
    <div class=" h-full flex bg-blue-100   p-4">
        <div class="w-full max-w-2xl mx-auto p-4 bg-white shadow-lg rounded-lg">
        <div class="p-4"><RouterLink  class="bg-blue-800 p-2  ml-120 rounded-lg w-30" :to="`/create`"><button class="text-white">Create New Note</button></RouterLink></div>
        <table class="min-w-full border border-gray-300">
          <thead class="bg-gray-200">
            <tr>
              <th class="border px-4 py-2 text-left">Title</th>
              <th class="border px-4 py-2 text-left">Created Date</th>
              <th class="border px-4 py-2 text-center">Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="note in notes"
              :key="note.id"
              class="hover:bg-gray-100 transition"
            >
              <td class="border px-4 py-2">
               
                  {{ note.title }}
               
              </td>
              <td class="border px-4 py-2">
                {{ new Date(note.createdAt).toLocaleString() }}
              </td>
             
              <td class="border px-4 py-2 text-center ">
                <RouterLink
                  :to="`/${note.id}`"
                  class="  px-3 py-1 rounded hover:text-yellow-500 inline-block"
                >
                <EyeIcon class="w-5 h-5" />
                </RouterLink>    
                <RouterLink
                  :to="`/edit/${note.id}`"
                  class="  px-3 py-1 rounded hover:text-yellow-500 inline-block"
                >
                <PencilIcon class="w-5 h-5" />
                </RouterLink>
                <RouterLink
                  class="  px-3 py-1 rounded hover:text-yellow-500 inline-block"
                >
                <TrashIcon @click="deletenote(note.id)" class="w-5 h-5" />
              </RouterLink>
              </td>
            </tr>
          </tbody>
        </table>
    </div>
    </div>
</template>
