// Mostrar / Ocultar as DIV dos pop-ups de consulta
function MostrarConteudo(e) {
    var display = document.getElementById(e).style.display;
    if (display == "none")
        document.getElementById(e).style.display = 'block';
    else
        document.getElementById(e).style.display = 'none';
}

//Pesquisa por paciente
//Apenas um
var idPaciente = document.getElementById("idPaciente");
var paciente = document.getElementById("nomeP");
var CPF = document.getElementById("CPF");
var numCarteira = document.getElementById("num_carteirinha");
var dtNasc = document.getElementById("dt_nascimento");
var dtCadastro = document.getElementById("dt_cadastro");
var logradouro = document.getElementById("logradouro");
var num = document.getElementById("num");
var complemento = document.getElementById("complemento");
var bairro = document.getElementById("bairro");
var cidade = document.getElementById("cidade");

function pesquisarPaciente(){
    var buscaPaciente = paciente.value;
        
   $.ajax({
       type:'GET',
       url:'http://localhost:5000/api/Paciente/PacientePorNome/'+buscaPaciente,
       success: function(retorno){
          idPaciente.value = retorno.id_paciente,
          paciente.value = retorno.nome,
          CPF.value = retorno.cpf,
          numCarteira.value = retorno.numCarteira,
          dtNasc.value = retorno.dt_nascimento,
          dtCadastro.value = retorno.dt_cadastro,
          logradouro.value = retorno.endereco.logradouro, 
          num.value = retorno.endereco.num, 
          complemento.value = retorno.endereco.complemento, 
          bairro.value = retorno.endereco.bairro, 
          cidade.value = retorno.endereco.cidade
       },
       error: function(erro){
          alert(erro.responseText);
       } 
   });
}

function limparFormPaciente(){
   idPaciente.value = "",
   paciente.value = "",
   CPF.value = "",
   numCarteira.value = "",
   dtNasc.value = "",
   dtCadastro.value = "",
   logradouro.value = "", 
   num.value = "", 
   complemento.value = "", 
   bairro.value = "", 
   cidade.value = ""
}

//Pesquisa por dentista
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

//Pesquisa por procedimento
// Apenas um
var idProcedimento = document.getElementById("idDentista");
var procedimento = document.getElementById("procedimento");
var duracao = document.getElementById("duracao");
var valor = document.getElementById("valor");

function pesquisarProcedimento(){}

function limparFormProcedimento(){
    idProcedimento.value = "";
    procedimento.value = "";
    duracao.value = "";
    valor.value = "";
}



// var numCarteira = document.getElementById("num_carteirinha");




