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

function pesquisarPaciente(){
    var buscaPaciente = paciente.value;
    var dataFormatada;
   $.ajax({
       type:'GET',
       url:'http://localhost:5000/api/Paciente/PacientePorNome/'+buscaPaciente,
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

function formatarData(){
    d=new Date(dtCadastro);
    dt=d.getDate();
    mn=d.getMonth();
    mn++;
    yy=d.getFullYear();
    dtCadastro.value=dt+"/"+mn+"/"+yy
}








// TELA DE CADASTRO
//Campos do formulário
var nomeP = document.getElementById("nome");
var CPFP = document.getElementById("CPF");
var nCarteirinha = document.getElementById("num_carteirinha");
var dtCadastro = document.getElementById("dt_cadastro");
var dtNascimento = document.getElementById("dt_nascimento");

var logradouro = document.getElementById("logradouro");
var numero = document.getElementById("num");
var complemento = document.getElementById("complemento");
var bairro = document.getElementById("bairro");
var cidade = document.getElementById("cidade");

var idTab = document.getElementById("idTabela");
var nomeTab = document.getElementById("nomeTabela");
var cpfTab = document.getElementById("cpfTabela");

// Validacao dos formularios
function validar() {
    var campoMensagem = document.getElementById("mensagem-info");
    if (nome.value == "")
        $(campoMensagem).append("O nome é obrigatório! Por favor preencha esse campo.");

    if (CPF.length > 14)
        $(campoMensagem).append("CPF incorreto! Por favor preencha com pontos e traço.");

    if (nCarteirinha.value == "")
        $(campoMensagem).append("O número da carteirinha é obrigatório! Por favor preencha esse campo.");

    if (logradouro.value = "")
        $(campoMensagem).append("O logradouro é obrigatório! Por favor preencha esse campo.");

    if (numero.value = "")
        $(campoMensagem).append("O número é obrigatório! Por favor preencha esse campo.");

    if (bairro.value = "")
        $(campoMensagem).append("O bairro é obrigatório! Por favor preencha esse campo.");

    if (cidade.value = "")
        $(campoMensagem).append("A cidade é obrigatória! Por favor preencha esse campo.");
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

//Tabela de pacientes
function preencherClientes(){
    
    $.ajax({
        type:'GET',
        url:'http://localhost:5000/api/Paciente',
        success: function(retorno){
           
            $('#tabPaciente').DataTable({
                "aaData": retorno,
                "aoColumns": [
                    { data: 'id_paciente', defaultContent: '' },
                    { data: 'nome', defaultContent: '' },
                    { data: 'cpf', defaultContent: '' }
                ],
              });

            for(var i=0; i < retorno.length; i++){
                      var dados = retorno[i];

                     
                // $('#tabPaciente').append(
                //     '<tr><td>'+dados[i].id_paciente+
                //     '</td><td>'+dados[i].nome+
                //     '</td><td>'+dados[i].cpf+
                //     '</td></tr>');
                //     nomeP.value = dados[2].nome;
          
            //     idTab.value = dados.id_paciente;
            //     nomeTab.value = dados.nome;
            //     cpfTab.value = dados.cpf;
            //     // console.log('ID:'+dados.id_paciente + 'Nome:'+dados.nome);
            }
            
           

          
        }
    });

}
