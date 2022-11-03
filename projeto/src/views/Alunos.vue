<template>
    <div class="main-container">
        <div id="tab-title">
            <label for="">Consulta de Alunos</label>
        </div>
        <div class="alunos-tab">
            <div>
                <router-link to="/cadastrar"><button class="btn btn-register">Cadastrar Aluno</button></router-link>
            </div>
        </div>
        <div>
            <DatatableVue />
        </div>
    </div>
    
</template>

<script>
    import DatatableVue from '../components/Datatable.vue';
  export default{
    name: 'Alunos',
    data() {
      return {
        cpf: ''
      }
    },
    methods:{
    },
    components:{
        DatatableVue
    },
    mounted(){
    }
  }
</script>

<style scoped>
.main-container{
    border: solid 2px #222;
}
    .main-container, #tab-title{
        border-top-left-radius: 8px;
        border-top-right-radius: 8px;
        margin-bottom: 10px;
    }
#tab-title{
    background-color: #ccc;
    border-bottom: solid 1px #999;
}
    #tab-title label{
        font-weight: 600;
        padding: 1rem;
        text-align: center;
        justify-content: center;
        margin: 0 auto;
        font-size: 16px;
        display: flex;
    }
.alunos-tab{
    padding: 1rem;
    align-items: center;
    margin: 0 auto;
}
    .alunos-tab div{
        margin-left: 87%;
    }
    .alunos-tab input, .btn-register{
        font-size: 16px;
        margin-bottom: 30px;
    }
    .alunos-tab .btn-register{
        position: relative;
    }
    

.btn{
    padding: 10px 15px;
    font-weight: 600;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}
.btn-search{
    background-color: rgb(0, 119, 255);
    border: solid 2px rgb(0, 108, 231);
    color:white;
    cursor: pointer;
}
    .btn-search:hover{
        background-color: white;
        color: black;
        transition: .5s;
        cursor: pointer;
    }
    .btn-search:disabled{
        color: white;
        background-color: #999;
        border: solid 2px #999;
    }

.btn-register{
    background-color: rgb(255, 196, 0);
    color: black;
    border: 2px solid rgb(247, 189, 0);
    cursor: pointer;
}
    .btn-register:hover{
            background-color: white;
            color: black;
            transition: .5s;
            cursor: pointer;
        }
</style>

