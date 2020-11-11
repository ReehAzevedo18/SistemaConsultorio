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
//Formulário de cadastro
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


//Enviando dados do formulário
// function pegarDados(){
//     var formPaciente = {
//         nome: nome.value,
//         CPF: CPF.value,
//         numCarteirinha: nCarteirinha.value,
//         dtCadastro: dtCadastro.value,
//         dtNascimento: dtNascimento.value,
//         Logradouro: logradouro.value,
//         num: numero.value,
//         compl: complemento.value,
//         bairro: bairro.value,
//         cidade: cidade.value
//     };
//     console.log(formPaciente);    
// }

// function enviarDados(){
//     const xhr = new XMLHttpRequest();
//     xhr.open('POST', '/Paciente', true);
//     xhr.setRequestHeader("Content-type", "application/json");
    
//     xhr.onreadystatechange = () =>{
//         if (xhr.readyState == 4){
//             if (xhr.status == 200){
//                 console.log("Enviado com sucesso!", xhr.responseText);
//             }else{
//                 console.log(xhr.responseText);
//             }
//         }
//     }
//     xhr.send(JSON.stringify(formPaciente));
// }

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

   
//     // let xhr = new XMLHttpRequest();
//     // xhr.open('GET', 'https://viacep.com.br/ws/88040400/json');
//     // xhr.onreadystatechange = () => {
//     //     if (xhr.readyState == 4){
//     //         if (xhr.status == 200){
//     //             preencherTabela(JSON.parse(xhr.responseText));
            
//     //         }
//     //     }
//     // }
    // xhr.send();

// function preencherTabela(json){
//     $('#id').text(json.bairro);
//     $('#nome').text(json.localidade);
//     $('#CPF').text(json.logradouro);
// }


//Formulário de consulta