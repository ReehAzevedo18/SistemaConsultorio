//CONSULTA NA HOME
// Apenas um
var idDentista = document.getElementById("idDentista");
var dentista = document.getElementById("dentista");
var CPF = document.getElementById("CPF");
var matricula = document.getElementById("matricula");
var logradouroD = document.getElementById("logradouroD");
var numD = document.getElementById("numD");
var complementoD = document.getElementById("complementoD");
var bairroD = document.getElementById("bairroD");
var cidadeD = document.getElementById("cidadeD");

function pesquisarDentista(){
    var buscaDentista = dentista.value;
        
    $.ajax({
        type:'GET',
        url:'http://localhost:5000/api/Dentista/DentistaPorNome/'+buscaDentista,
        success: function(retorno){
            idDentista.value = retorno.id_dentista,
            dentista.value = retorno.nome,
            CPF.value = retorno.cpf,
            matricula.value = retorno.matricula,
            logradouroD.value = retorno.endereco.logradouro, 
            numD.value = retorno.endereco.num, 
            complementoD.value = retorno.endereco.complemento, 
            bairroD.value = retorno.endereco.bairro, 
            cidadeD.value = retorno.endereco.cidade
         
         },
        error: function(erro){
           alert(erro.responseText);
        } 
    });
}

function limparFormDentista(){
idDentista.value = "";
dentista.value = "";
CPF.value = "";
matricula.value = "";
logradouroD.value = "";
numD.value = "";
complementoD.value = "";
bairroD.value = "";
cidadeD.value = "";
}


//Tabela de pacientes
function preencherDentistas(){

    $.ajax({
        type:'GET',
        url:'http://localhost:5000/api/Dentista',
        success: function(retorno){
                for(i=0; i < retorno.length; i++){
                    var dado = retorno[i];
                    $("#tabDentista tbody").append(
                        "<tr>"+
                        "<td>"+dado.id_dentista+"</td>"+
                        "<td>"+dado.nome+"</td>"+
                        "<td>"+dado.cpf+"</td>"+
                        "<td>"+dado.matricula+"</td>"+
                        +"</tr>");
                }        
        },
        error: function(erro){
            alert("Deu erro: "+erro.responseText);
         } 
    });

}