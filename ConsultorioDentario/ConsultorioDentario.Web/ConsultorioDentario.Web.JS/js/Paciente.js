//CONSULTA DE PACIENTE NA HOME
//Apenas um
var idPaciente = document.getElementById("idPaciente");
var paciente = document.getElementById("paciente");
var CPF = document.getElementById("CPF");
var numCarteira = document.getElementById("num_carteirinha");
var dtNasc = document.getElementById("dt_nascimento");
var dtCadastro = document.getElementById("dt_cadastro");
var logradouro = document.getElementById("logradouro");
var num = document.getElementById("num");
var complemento = document.getElementById("complemento");
var bairro = document.getElementById("bairro");
var cidade = document.getElementById("cidade");

function pesquisarPaciente(paciente){
    var buscaPaciente = paciente.value;
   $.ajax({
       type:'GET',
       url:'https://localhost:44300/api/Paciente/PacientePorNome/'+buscaPaciente,
       success: function(retorno){
          idPaciente.value = retorno.id_paciente,
          paciente.value = retorno.nome,
          CPF.value = retorno.cpf,
          numCarteira.value = retorno.numCarteira,
          dtNasc.value = retorno.dt_nascimento.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1'),
          dtCadastro.value = retorno.dt_cadastro.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1'),
          logradouro.value = retorno.endereco.logradouro, 
          num.value = retorno.endereco.num, 
          complemento.value = retorno.endereco.complemento, 
          bairro.value = retorno.endereco.bairro, 
          cidade.value = retorno.endereco.cidade
       },
       error: function(erro){
          alert("Deu erro: "+erro.responseText);
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


function formatarData(){
    d=new Date(dt_cadastro);
    dt=d.getDate();
    mn=d.getMonth();
    mn++;
    yy=d.getFullYear();
    dtCadastro.value=dt+"/"+mn+"/"+yy
}


//Tabela de pacientes
function preencherClientes(){

    $.ajax({
        type:'GET',
        url:'https://localhost:44300/api/Paciente',
        success: function(retorno){
                for(i=0; i < retorno.length; i++){
                    var dado = retorno[i];
                    $("#tabPaciente tbody").append(
                        "<tr>"+
                        "<td>"+dado.id_paciente+"</td>"+
                        "<td>"+dado.nome+"</td>"+
                        "<td>"+dado.cpf+"</td>"+
                        "<td>"+dado.numCarteira+"</td>"+
                        "<td>"+dado.dt_cadastro.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1')+"</td>"+
                        +"</tr>");
                }        
        },
        error: function(erro){
            alert("Deu erro: "+erro.responseText);
         } 
    });

}

// TELA DE CADASTRO
//Campos do formulário

var nomeP = document.getElementById("Nome");
var cpf = document.getElementById("CPF");
var nCarteirinha = document.getElementById("numCarteira");
var dtCadastro = document.getElementById("dt_cadastro");
var dtNascimento = document.getElementById("dt_nascimento");

var logradouro = document.getElementById("logradouro");
var numero = document.getElementById("num");
var complemento = document.getElementById("complemento");
var bairro = document.getElementById("bairro");
var cidade = document.getElementById("cidade");

// Validacao dos formularios
function validar() {
    var campoMensagem = document.getElementById("mensagem-info");
    if (nomeP.value == "" || nomeP.value == null)
        $(campoMensagem).append("O nome é obrigatório! Por favor preencha esse campo.");
}

//Data de Cadastro
var dataAtual = new Date();
var data = dataAtual.getFullYear().toString() + "-0" + dataAtual.getMonth().toString() + "-" + dataAtual.getDate().toString();
document.getElementById("dt_cadastro").value = data;

//Gerando número da carteira do paciente
 function gerarNumCarteirinha() {
    nCarteirinha.value = Math.round((10000000 + Math.random() * 99999999));
    // nCarteirinha.value = (Math.random() * 9);
}

function salvar(){
  // validar(); 
    //  e.preventDefault();
      //var URL = "https://localhost:44300/api/Paciente";
      if(isValidCPF(cpf)== true){
          console.log("CPF válido");
          var CPFValidado = cpf;
      }

      var dados = ({
        Nome: nomeP.value,
        CPF: CPFValidado,
        numCarteira: nCarteirinha.value,
        dt_nascimento: dt_nascimento.value,
        dt_cadastro: dt_cadastro.value,
        endereco: {
            logradouro: logradouro.value,
            num: num.value,
            complemento: complemento.value,
            bairro: bairro.value,
            cidade: cidade.value
        }
    })
    console.log(dados);


      /* axios.post(URL, {
         
      })
      .then(function (response) {
            alert(response.data.message);
      })
      .catch(function (err) {
        alert("Ocorreu um erro ao realizar o cadasro! Entre em contato com o suporte.")
        console.log(err);
      }); */
}

function oPaciente(){
    var URL = "https://localhost:44300/api/Paciente";

    axios.get(URL)
    .then(function (response) {    
            for(i=0; i < response.data.length; i++){
                var dado = response.data[i];
              
                    $("#pacienteCadastrados tbody").append(
                        "<tr>"+
                        "<td>"+dado.id_paciente+"</td>"+
                        "<td>"+dado.nome+"</td>"+
                        "<td>"+dado.cpf+"</td>"+
                   +"</tr>");
        } 
    })
    .catch(function (err) {
      console.log(err);
    })    
      
}

function isValidCPF(cpf) {
    if (typeof cpf !== "string") return false
    cpf = cpf.replace(/[\s.-]*/igm, '')
    if (
        !cpf ||
        cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999" 
    ) {
        return false
    }
    var soma = 0
    var resto
    for (var i = 1; i <= 9; i++) 
        soma = soma + parseInt(cpf.substring(i-1, i)) * (11 - i)
    resto = (soma * 10) % 11
    if ((resto == 10) || (resto == 11))  resto = 0
    if (resto != parseInt(cpf.substring(9, 10)) ) return false
    soma = 0
    for (var i = 1; i <= 10; i++) 
        soma = soma + parseInt(cpf.substring(i-1, i)) * (12 - i)
    resto = (soma * 10) % 11
    if ((resto == 10) || (resto == 11))  resto = 0
    if (resto != parseInt(cpf.substring(10, 11) ) ) return false
    return true
}