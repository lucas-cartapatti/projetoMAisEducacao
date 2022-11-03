<template>
    <div class="message-container">
        <p>{{msg}}</p>
        <div>
            <button class='btn btn-delete' @click="DeletarRegistro(id_aluno)">Confirmar</button>
            <router-link to="/alunos"><button class="btn btn-cancel" @click="RollbackDelete()">Cancelar</button></router-link>
        </div>
    </div>
</template>
<script>
export default{
    name: 'Message',
    props:{
        msg: String,
        id_aluno: Number
    },
    methods:{
        RollbackDelete(){
            var t = document.getElementsByClassName('message-container');
            t[0].style.display = 'none';
        },
        async DeletarRegistro(id){
            const req = await fetch(`https://localhost:62388/api/Alunos/deletar/${id}`,{
                method: 'DELETE'
            });

            alert(`O registro RA: ${id} foi deletado da base...`);
          
            location.reload();
        }

    }
}
</script>
<style scoped>
.message-container {
    color: rgb(247, 199, 111);
    background-color:cadetblue;
    padding: 10px;
    margin: 0 auto;
    text-align: center;
    transition: 0.5s;
}
p{
    font-size: 18px;
}

.btn{
    font-weight: 600;
    border-radius: 4px;
    padding: 10px;
    font-size: 14px;
    margin: 0 auto;
    cursor: pointer;
    transition: .5s;
    margin-left: 10px;  
}
.btn-cancel{
    background-color: rgb(0, 119, 255);
    border: solid 2px rgb(0, 108, 231);
    color:white
}

.btn-delete{
    background-color: rgb(255, 45, 45);
    color: white;
    border: 2px solid rgb(247, 0, 0);
}
    .btn-cancel:hover, 
    .btn-delete:hover{
        background-color: white;
        border: solid 2px #222;
        color: #222;
    }
</style>