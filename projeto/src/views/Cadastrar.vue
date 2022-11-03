<template>
    <form class="main-container" @submit="SalvarCadastro($event)">
        <div id="tab-title">
            <label for="">Cadastro de Aluno</label>
        </div>
        <div class="alunos-tab">
            <div>
                <label for="nome">Nome</label>
                <input name="nome" v-model="nome" type="text" placeholder="ex: João Silva">
            </div>
            <div>
                <label for="email">E-mail</label>
                <input name="email" v-model="email" type="text" placeholder="ex: joao.silva@email.com">
            </div>
            <div v-if="!isEditing">
                <label for="ra">RA</label>
                <input  name="ra" type="text" placeholder="ex: 1234567" v-model="ra" v-mask="'0000000'">
            </div>
            <div>
                <label for="cpf">CPF</label>
                <input name="cpf" type="text" placeholder="123.456.789-89" v-model="cpf" v-mask-cpf>
                
            </div>
            <div id="btn-div">
                <div>
                    <router-link to="/alunos"><button class="btn btn-cancel">Cancelar</button></router-link>
                    <button :id="ra" class="btn btn-save" type="submit" >Salvar</button>
                </div>
            </div>
        </div>
    </form>
</template>

<script>
import { tSExpressionWithTypeArguments } from '@babel/types';

    export default{
        name: 'Cadastrar',
        data() {
            return {
                id: this.$route.params.id,
                isEditing: false,

                nome: null,
                email: null,
                cpf: null,
                ra: null
            }
        },
        methods: {
            async SalvarCadastro(e){
                e.preventDefault();

                const data = {
                        Ra : this.ra,
                        Nome : this.nome,
                        Email : this.email,
                        Cpf : this.cpf
                    };
                const dataJson = JSON.stringify(data);

                if(this.id != undefined){
                    const req = await fetch('https://localhost:62388/api/Alunos/atualizar', {
                        method:'PUT',
                        headers:{'Content-Type': 'application/json'},
                        body: dataJson
                    });
                    const res = await req.json();
                    
                    if(res.status === 200){
                        alert('Registro atualizado com sucesso');
                    }else{
                        alert('Não foi possível atualizar o cadastro: ' + res.message)
                    }                    
                }else{
    
                    const req = await fetch('https://localhost:62388/api/Alunos/cadastrar', {
                        method:'POST',
                        headers:{'Content-Type': 'application/json'},
                        body: dataJson
                    });
                    const res = await req.json();
                    
                    if(res.status === 200){
                        alert('Registro enviado ao servidor com sucesso');
                    }else{
                        alert('Não foi possível realizar o cadastro: ' + res.message)
                    }
                    this.id = null;
                    this.nome = null;
                    this.email = null;
                    this.cpf = null;
                    this.ra = null;
                }

            },

            async CarregarCadastro(id){
                const req = await fetch(`https://localhost:62388/api/Alunos/Id/${id}`);
                const data = await req.json();

                const aluno = data;
                if(aluno.length > 0){
                    this.nome = aluno[0].Nome;
                    this.cpf = aluno[0].Cpf;
                    this.ra = aluno[0].Ra;
                    this.email = aluno[0].Email;

                    this.isEditing = true;
                }
                
            }

        },
        mounted() {
            if(this.id != undefined){
                const n_id = parseInt(this.id);

                this.CarregarCadastro(n_id);
                //CarregarAluno(this.id);
            }
        }
    }
</script>

<style scoped>
.main-container{
    border: solid 2px #222;
    float:left;
    width: 79%;
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
    margin: 0 auto;
    align-items: center;
}
    .alunos-tab input{
        width: 350px;
        padding: 10px;
        display: flex;
        border: solid 2px #ccc;
        border-top-right-radius: 4px;
        border-bottom-right-radius: 4px;
        
    }
    .alunos-tab label{
        display: table;
        padding: 10px;
        padding-left: 10px;
        text-align: justify;
    }
    .alunos-tab input, .btn-save, .btn-cancel{
        font-size: 16px;
        margin-bottom: 30px;
    }

.btn{
    padding: 10px 20px;
    font-weight: 600;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.btn-save{
    background-color: rgb(0, 119, 255);
    border: solid 2px rgb(0, 108, 231);
    color:white
}

.btn-cancel{
    background-color: rgb(255, 196, 0);
    color: black;
    border: 2px solid rgb(247, 189, 0);
}
    .btn-cancel:hover,
    .btn-save:hover{
            background-color: white;
            color: #222;
            border: solid 2px #222;
            transition: .5s;
        }
#btn-div{
    display: flex;
    justify-content: end;
}
#btn-div .btn-save{
    margin-left: 10px;
}
#btn-div .btn-cancel{
    margin-left: 10px;
}

.alunos-tab a{
    margin: 0 auto;
    padding-left: 10px;
}
</style>
