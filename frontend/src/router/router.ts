import { createRouter, createWebHistory } from "vue-router";
import NoteList from "@/views/NoteList.vue";
import NoteForm from "@/views/NoteForm.vue";
import NoteItem from "@/views/NoteItem.vue";
import EditNote from "@/views/EditNote.vue";

const routes = [
  { path: "/", component: NoteList },
  { path: "/create", component: NoteForm },
  { path: "/:id", component: NoteItem, props: true },
  { path: "/edit/:id", component: EditNote, props: true }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
