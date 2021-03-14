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
        url:'https://localhost:44300/api/Procedimento/ProcedimentoPorNome/'+buscaProcedimento,
        success: function(retorno){
            console.log(retorno);
            idProcedimento.value = retorno.id_procedimento,
            procedimento.value = retorno.procedimento,
            duracao.value = retorno.duracao,
            valor.value = retorno.valor
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
function preencherProcedimentos(){

    $.ajax({
        type:'GET',
        url:'https://localhost:44300/api/Procedimento',
        success: function(retorno){
                for(i=0; i < retorno.length; i++){
                    var dado = retorno[i];
                    $("#tabProcedimento tbody").append(
                        "<tr>"+
                        "<td>"+dado.id_procedimento+"</td>"+
                        "<td>"+dado.procedimento+"</td>"+
                        "<td>"+dado.duracao+"</td>"+
                        "<td>"+dado.valor+"</td>"+
                        +"</tr>");
                }        
        },
        error: function(erro){
            alert("Deu erro: "+erro.responseText);
         } 
    });

}