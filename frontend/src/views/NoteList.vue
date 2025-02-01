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
    <div class="h-full flex bg-gray-300   p-4">
        <div class="w-full max-w-2xl mx-auto p-4 bg-white shadow-lg rounded-lg">
        <div class="p-4"><RouterLink  class="bg-blue-800 p-2  ml-120 rounded-lg w-30" :to="`/create`"><button>Create New Note</button></RouterLink></div>
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
              <td class="border px-6 py-2">
                {{ note.createdAt }}
              </td>
             
              <td class="border px-4 py-2 text-center">
                <RouterLink
                  :to="`/${note.id}`"
                  class="  px-3 py-1 rounded hover:text-yellow-500"
                >
                <EyeIcon class="w-5 h-5" />
                </RouterLink>    
                <RouterLink
                  :to="`/edit/${note.id}`"
                  class="  px-3 py-1 rounded hover:text-yellow-500"
                >
                <PencilIcon class="w-5 h-5" />
                </RouterLink>

               <TrashIcon @click="deletenote(note.id)" class="w-5 h-5 hover:text-red-500" />
              </td>
            </tr>
          </tbody>
        </table>
    </div>
    </div>
</template>
