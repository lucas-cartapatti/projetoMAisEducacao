<template>
    <div class="search-tab">
        <input @change="CarregarAlunos" id="search-field" type="text" placeholder="Digite o número do CPF" v-model="cpf" v-mask-cpf>
        <button @click="CarregarAlunos" id="search-button" value="Pesquisar" class="btn btn-search">Pesquisar</button>
    </div>
    <div id="table-register">
        <div>
            <div id="table-header">
                <div class="register-id">Registro Acadêmico</div>
                <div>Nome</div>
                <div>CPF</div>
                <div>Ações</div>
            </div>
            <ModalVue :msg="msg" :id_aluno="id_aluno" v-show="msg" />
            <div id="table-rows">
                <!-- v-for -->
                <div class="table-row" v-for="aluno in alunos" :key="aluno.Ra"> 
                    <div class="register-number">{{aluno.Ra}}</div>
                    <div>{{aluno.Nome}}</div>
                    <div>{{aluno.Cpf}}</div>
                    <div>
                        <router-link :to="{ name: 'Editar', params: {id: aluno.Ra}}"><button class="btn btn-edit">Editar</button></router-link>
                        <button class="btn btn-delete" @click="ModalDeletar(aluno)">Deletar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import ModalVue from './Modal.vue'
    
    export default{
        name: 'Datatable',
        data() {
            return {
                alunos: [],
                aluno: null,

                nome: null,
                cpf: '',
                ra: null,
                msg:null
            }
        },
        methods:{
            async CarregarAlunos(){

                if(this.cpf.length == 14){
                    const req = await fetch(`https://localhost:62388/api/Alunos/${this.cpf}`);
                    const data = await req.json();

                    console.log(data);
                    this.alunos = data;
                }else{
                    const req = await fetch('https://localhost:62388/api/Alunos');
                    const data = await req.json();
    
                    console.log(data);
                    this.alunos = data;
                }
            },


            ModalDeletar(data){
                var t = document.getElementsByClassName('message-container');
                if(t[0].style.display === 'none'){
                    t[0].style.display = ''
                }
                this.msg = `Deseja Realmente Apagar o registro ${data.Ra} do aluno ${data.Nome}?`
                this.id_aluno = data.Ra;
            },
        },
        components:{
            ModalVue
        },
        mounted() {
            this.CarregarAlunos();
        },
    }
</script>

<style scoped>
.search-tab{
    border-bottom: solid 2px;
    margin: 0 auto;
}
    .search-tab #search-field{
        width: 350px;
        padding: 10px;
        border: solid 2px #ccc;
        border-top-left-radius: 4px;
        border-bottom-left-radius: 4px;
    }
    .search-tab input, .btn-search, .btn-register{
        font-size: 16px;
    }
    .search-tab .btn-register{
        margin-left: 10px;
    }

  #table-register {
    max-width: 100%;
    min-height: 500px;
    margin: 0 auto;
  }
  #table-header,
  #table-rows,
  .table-row
  {
    display: flex;
    flex-wrap: wrap;
  }

  #table-header{
    font-weight: bold;
    padding: 18px;
    border-bottom: 3px solid #333;
    background-color: #ddd;
  }
  .table-row{
    width: 100%;
    padding: 18px;
    border-bottom: 1px solid #CCC;
  }

  #table-header div,
  .table-row div{
    width: 25%;
  }

.btn {
    font-weight: 600;
    border-radius: 4px;
    padding: 10px;
    font-size: 14px;
    margin: 0 auto;
    cursor: pointer;
    transition: .5s;
    margin-left: 10px;    
}
.btn-search{
    background-color: rgb(0, 119, 255);
    border: solid 2px rgb(0, 108, 231);
    border-top-left-radius: 0;
    border-bottom-left-radius: 0;
    color:white;   
    margin-left: 0;
}

.btn-edit{
    background-color: rgb(0, 119, 255);
    border: solid 2px rgb(0, 108, 231);
    color:white
}

.btn-delete{
    background-color: rgb(255, 196, 0);
    color: black;
    border: 2px solid rgb(247, 189, 0);
}
    .btn-edit:hover, 
    .btn-search:hover,
    .btn-delete:hover{
        background-color: white;
        border: solid 2px #222;
        color: #222;
    }
</style>