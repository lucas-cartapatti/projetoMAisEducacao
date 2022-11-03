<template>
    <header>
        <div id="header-tab">
            <router-link to="/"><img :src="logo" :alt="alt" id="logo"></router-link>
        </div>
    </header>
</template>

<script>
    export default{
        name: 'Header',
        props:['logo','alt'],
        data() {
            return {
                
            }
        }
    }
</script>

<style scoped>
#header-tab{
    background-color: #ccc;
    height: fit-content;
    width: 100%;
    border-bottom: solid 1px #999;
}
#header-tab div, a{
    padding: 1rem;
    margin: 0 auto;
}
#header-tab img{
    width: 140px;
}
    #header-tab img:hover{
        opacity: .7;
    }
</style>