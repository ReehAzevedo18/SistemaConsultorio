// Mostrar / Ocultar as DIV dos pop-ups de consulta
function MostrarConteudo(e) {
    var display = document.getElementById(e).style.display;
    if (display == "none")
        document.getElementById(e).style.display = 'block';
    else
        document.getElementById(e).style.display = 'none';
}

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
    nomeP.value = "",
    cpf.value = "",
    nCarteirinha.value = "",
    dtNascimento.value = "",
    dtCadastro.value = "",
    logradouro.value = "", 
    num.value = "", 
    complemento.value = "", 
    bairro.value = "", 
    cidade.value = ""
 }

//Mascarar CPF
function mascara(i){
   
    var v = i.value;
    
    if(isNaN(v[v.length-1])){ // impede entrar outro caractere que não seja número
       i.value = v.substring(0, v.length-1);
       return;
    }
    
    i.setAttribute("maxlength", "14");
    if (v.length == 3 || v.length == 7) i.value += ".";
    if (v.length == 11) i.value += "-";
 
 }
//Mascarar datas
function mascaraData(val) {
    var pass = val.value;
    var expr = /[0123456789]/;
  
    for (i = 0; i < pass.length; i++) {
      // charAt -> retorna o caractere posicionado no índice especificado
      var lchar = val.value.charAt(i);
      var nchar = val.value.charAt(i + 1);
  
      if (i == 0) {
        // search -> retorna um valor inteiro, indicando a posição do inicio da primeira
        // ocorrência de expReg dentro de instStr. Se nenhuma ocorrencia for encontrada o método retornara -1
        // instStr.search(expReg);
        if ((lchar.search(expr) != 0) || (lchar > 3)) {
          val.value = "";
        }
  
      } else if (i == 1) {
  
        if (lchar.search(expr) != 0) {
          // substring(indice1,indice2)
          // indice1, indice2 -> será usado para delimitar a string
          var tst1 = val.value.substring(0, (i));
          val.value = tst1;
          continue;
        }
  
        if ((nchar != '/') && (nchar != '')) {
          var tst1 = val.value.substring(0, (i) + 1);
  
          if (nchar.search(expr) != 0)
            var tst2 = val.value.substring(i + 2, pass.length);
          else
            var tst2 = val.value.substring(i + 1, pass.length);
  
          val.value = tst1 + '/' + tst2;
        }
  
      } else if (i == 4) {
  
        if (lchar.search(expr) != 0) {
          var tst1 = val.value.substring(0, (i));
          val.value = tst1;
          continue;
        }
  
        if ((nchar != '/') && (nchar != '')) {
          var tst1 = val.value.substring(0, (i) + 1);
  
          if (nchar.search(expr) != 0)
            var tst2 = val.value.substring(i + 2, pass.length);
          else
            var tst2 = val.value.substring(i + 1, pass.length);
  
          val.value = tst1 + '/' + tst2;
        }
      }
  
      if (i >= 6) {
        if (lchar.search(expr) != 0) {
          var tst1 = val.value.substring(0, (i));
          val.value = tst1;
        }
      }
    }
  
    if (pass.length > 10)
      val.value = val.value.substring(0, 10);
    return true;
}

//Validação de CPF
function validaCpfCnpj(val) {
    if (val.length == 14) {
        var cpf = val.trim();
     
        cpf = cpf.replace(/\./g, '');
        cpf = cpf.replace('-', '');
        cpf = cpf.split('');
        
        var v1 = 0;
        var v2 = 0;
        var aux = false;
        
        for (var i = 1; cpf.length > i; i++) {
            if (cpf[i - 1] != cpf[i]) {
                aux = true;   
            }
        } 
        
        if (aux == false) {
            return false; 
        } 
        
        for (var i = 0, p = 10; (cpf.length - 2) > i; i++, p--) {
            v1 += cpf[i] * p; 
        } 
        
        v1 = ((v1 * 10) % 11);
        
        if (v1 == 10) {
            v1 = 0; 
        }
        
        if (v1 != cpf[9]) {
            return false; 
        } 
        
        for (var i = 0, p = 11; (cpf.length - 1) > i; i++, p--) {
            v2 += cpf[i] * p; 
        } 
        
        v2 = ((v2 * 10) % 11);
        
        if (v2 == 10) {
            v2 = 0; 
        }
        
        if (v2 != cpf[10]) {
            return false; 
        } else {   
            return true; 
        }
    } else if (val.length == 18) {
        var cnpj = val.trim();
        
        cnpj = cnpj.replace(/\./g, '');
        cnpj = cnpj.replace('-', '');
        cnpj = cnpj.replace('/', ''); 
        cnpj = cnpj.split(''); 
        
        var v1 = 0;
        var v2 = 0;
        var aux = false;
        
        for (var i = 1; cnpj.length > i; i++) { 
            if (cnpj[i - 1] != cnpj[i]) {  
                aux = true;   
            } 
        } 
        
        if (aux == false) {  
            return false; 
        }
        
        for (var i = 0, p1 = 5, p2 = 13; (cnpj.length - 2) > i; i++, p1--, p2--) {
            if (p1 >= 2) {  
                v1 += cnpj[i] * p1;  
            } else {  
                v1 += cnpj[i] * p2;  
            } 
        } 
        
        v1 = (v1 % 11);
        
        if (v1 < 2) { 
            v1 = 0; 
        } else { 
            v1 = (11 - v1); 
        } 
        
        if (v1 != cnpj[12]) {  
            return false; 
        } 
        
        for (var i = 0, p1 = 6, p2 = 14; (cnpj.length - 1) > i; i++, p1--, p2--) { 
            if (p1 >= 2) {  
                v2 += cnpj[i] * p1;  
            } else {   
                v2 += cnpj[i] * p2; 
            } 
        }
        
        v2 = (v2 % 11); 
        
        if (v2 < 2) {  
            v2 = 0;
        } else { 
            v2 = (11 - v2); 
        } 
        
        if (v2 != cnpj[13]) {   
            return false; 
        } else {  
            return true; 
        }
    } else {
        return false;
    }
 }

//Editar pacientes
document.getElementById("btnPesquisarPaciente").addEventListener("click", function(event){
    
    document.getElementById("paciente").disabled = true;
    document.getElementById("CPF").disabled = true;
    document.getElementById("num_carteirinha").disabled = true;
    document.getElementById("dt_nascimento").disabled = true;
    document.getElementById("dt_cadastro").disabled = true;
    document.getElementById("logradouro").disabled = true;
    document.getElementById("num").disabled = true;
    document.getElementById("complemento").disabled = true;
    document.getElementById("bairro").disabled = true;
    document.getElementById("cidade").disabled = true;
});

document.getElementById("btnEditarPaciente").addEventListener("click", function(event){
    
    document.getElementById("paciente").disabled = false;
    document.getElementById("CPF").disabled = false;
    document.getElementById("dt_nascimento").disabled = false;
    document.getElementById("logradouro").disabled = false;
    document.getElementById("num").disabled = false;
    document.getElementById("complemento").disabled = false;
    document.getElementById("bairro").disabled = false;
    document.getElementById("cidade").disabled = false;
});

/* function buscarIdPaciente(){
    var URL = "https://localhost:44300/api/Paciente/PacientePorID";
    var id = idPaciente.value;
    var id_convertido = parseInt(id);

    axios.get(URL + '/' + id_convertido)
        .then(function (response) {
             if(response.data.id_paciente == id_convertido){
                 editarPaciente(id_convertido);
             }else{
                 alert("Paciente não localizado! Por favor, verifique o nome e tente novamente.")
             }
        })
        .catch(function (err) {
          console.log(err);
        })   
} */

function editarPaciente(){
    URL = "https://localhost:44300/api/Paciente";
    var id = idPaciente.value;
    var id_convertido = parseInt(id);

    if(validaCpfCnpj(CPF.value) == true){
        var CPFValidado = CPF.value;
        axios
        .put(+ '/' + id_convertido, {
            Nome: paciente.value,
            CPF: CPFValidado,
            numCarteira: numCarteira.value,
            dt_nascimento: dtNasc.value,
            dt_cadastro: dtCadastro.value,
            endereco: {
                logradouro: logradouro.value,
                num: num.value,
                complemento: complemento.value,
                bairro: bairro.value,
                cidade: cidade.value
            }
        })
        .then(function (response) {   
            alert(response.data.message);        
        })
        .catch(function (err) {
          console.log(err);
        }) 
    }else{
        var msgError = document.getElementById("mensagem-info-cpf");
        $(msgError).append("CPF inválido! Por favor, verifique.");
       return false;  
}
}