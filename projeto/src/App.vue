<template>
  <HeaderVue :logo="logo_src" :alt="app_name" />
  <div>
    <NavbarVue />
    <router-view/>
  </div>
</template>

<script>
  import NavbarVue from './components/Navbar.vue'
  import HeaderVue from './components/Header.vue';
  export default{
    name: 'App',
    data(){
      return {
        logo_src: '/img/logo.png',
        app_name: 'Grupo A'
      }
    },
    components:{
      NavbarVue,
      HeaderVue
    }
  }
</script>

<style>
#app{
  font-family: Arial, Helvetica, sans-serif;
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}
</style>
