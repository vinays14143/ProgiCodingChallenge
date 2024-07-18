<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <DataTable msg="Welcome to Your Vue.js App"/>
</template>

<script>
import DataTable from './components/DataTable.vue';

export default {
  name: 'App',
  components: {
    DataTable
  }
}
</script>

