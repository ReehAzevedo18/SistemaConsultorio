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
            console.log(retorno);
            // idDentista.value = retorno.id_dentista,
            // dentista.value = "";
            // CPF.value = "";
            // matricula.value = "";
            // logradouroD.value = "";
            // numD.value = "";
            // complementoD.value = "";
            // bairroD.value = "";
            // cidadeD.value = "";
         }
         //,
        // error: function(erro){
        //    alert(erro.responseText);
        // } 
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
