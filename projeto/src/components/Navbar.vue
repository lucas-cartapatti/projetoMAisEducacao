<template>
    <div id="nav">
        <div>
            <label for="">Módulo Acadêmico</label>
        </div>
        <div>
            <router-link to="/alunos"><button class="tablinks">Alunos</button></router-link>
        </div>
    </div>
</template>
<script>
</script>
<style scoped>
#nav{
    float: left;
    border: 1px solid #ccc;
    background-color: #f1f1f1;
    width: 20%;
    min-height: 800px;
    border: solid 2px #222;
}

#nav button{
    display: block;
    background-color: inherit;
    color: black;
    padding: 22px 16px;
    width: 100%;
    border: none;
    outline: none;
    text-align: center;
    cursor: pointer;
    transition: .5s;
    font-size: 18px;
}
    #nav button:hover{
        background-color: #ddd;
    }
    #nav button:active{
        background-color: #ccc;
    }

#nav a{
    text-decoration: none;
}
#nav label{
    text-align: center;
    padding: 1rem;
    background-color: #666;
    margin: 0 auto;
    display: flex;
    justify-content: center;
    color: azure;
    font-weight: 600;
}
</style>