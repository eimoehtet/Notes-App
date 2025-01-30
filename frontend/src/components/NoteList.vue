<template>
  <div >
    <h1>{{ title }}</h1>
  </div>
</template>

<script>
export default {
  name: 'NoteList',
  props: {
    title: String
  }
}
</script>
