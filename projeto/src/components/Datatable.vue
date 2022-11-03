<template>
    <div id="table-register">
        <div>
            <div id="table-header">
                <div class="register-id">Registro Acadêmico</div>
                <div>Nome</div>
                <div>CPF</div>
                <div>Ações</div>
            </div>
            <div id="table-rows">
                <!-- v-for -->
                <div class="table-row" v-for="aluno in alunos" :key="aluno.ra"> 
                    <div class="register-number">{{aluno.ra}}</div>
                    <div>{{aluno.nome}}</div>
                    <div>{{aluno.cpf}}</div>
                    <div>
                        <router-link to="/cadastrar/aluno.ra"><button class="btn btn-edit">Editar</button></router-link>
                        <button class="btn btn-delete">Deletar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default{
        name: 'Datatable',
        data() {
            return {
                alunos: null,

                nome: 'Jamboriano',
                cpf: '123.456.879-78',
                ra: 1234234,
            }
        },
        methods:{

        }
    }
</script>

<style scoped>
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
    .btn-delete:hover{
        background-color: white;
        border: solid 2px #222;
        color: #222;
    }
</style>