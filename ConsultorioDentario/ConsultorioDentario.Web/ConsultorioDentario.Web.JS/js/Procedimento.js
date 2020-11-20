//CONSULTA NA HOME
// Apenas um
var idProcedimento = document.getElementById("idProcedimento");
var procedimento = document.getElementById("procedimento");
var duracao = document.getElementById("duracao");
var valor = document.getElementById("valor");

function pesquisarProcedimento(){
    var buscaProcedimento = procedimento.value;
        console.log(buscaProcedimento);
    $.ajax({
        type:'GET',
        url:'http://localhost:5000/api/Procedimento/ProcedimentoPorNome/'+buscaProcedimento,
        success: function(retorno){
            console.log(retorno);
    
         }
         ,
        error: function(erro){
            console.log(erro);
        } 
    });
}

function limparFormProcedimento(){
    idProcedimento.value = "";
    procedimento.value = "";
    duracao.value = "";
    valor.value = "";
}

//Todos os procedimentos