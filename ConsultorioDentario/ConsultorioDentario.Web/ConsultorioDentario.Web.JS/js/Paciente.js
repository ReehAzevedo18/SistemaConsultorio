document.addEventListener("DOMContentLoaded", function(event) {
    oPaciente();
    preencherClientes()
  });
  
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
                        "<td id='id_paciente'>"+dado.id_paciente+"</td>"+
                        "<td>"+dado.nome+"</td>"+
                        "<td>"+dado.cpf+"</td>"+
                        "<td>"+dado.numCarteira+"</td>"+
                        "<td>"+dado.dt_cadastro.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1')+"</td>"+
                        "<td>"+dado.dt_nascimento.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1')+"</td>"+
                        "<td><button type='button' class='btn btn-danger btn-sm float-right' onclick='excluirPaciente()'>Excluir</button></td>"+
                        +"</tr>");
                }        
        },
        error: function(erro){
            alert("Deu erro: "+erro.responseText);
         } 
    });

}

