document.addEventListener("DOMContentLoaded", function(event) {
    preencherClientes()
  });
  
  
//Tabela de pacientes
function preencherClientes(){

        var URL = "https://localhost:44300/api/Paciente";
    
        axios.get(URL)
        .then(function (response) {    
                for(i=0; i < response.data.length; i++){
                    var dado = response.data[i];
                  
                        $("#tabPaciente tbody").append(
                            "<tr>"+
                            "<td>"+dado.id_paciente+"</td>"+
                            "<td>"+dado.nome+"</td>"+
                            "<td>"+dado.cpf+"</td>"+
                            "<td>"+dado.numCarteira+"</td>"+
                            "<td>"+dado.dt_nascimento+"</td>"+
                            "<td>"+dado.dt_cadastro+"</td>"+
                            "<td><button type='button' class='btn btn-danger btn-sm float-right' onclick='excluirPaciente("+dado.id_paciente+")'>Excluir</button></td>"+
                       +"</tr>");
                } 
        })
        .catch(function (err) {
          console.log(err);
        })    
}


function excluirPaciente(idPaciente){
    var URL = 'https://localhost:44300/api/Paciente';

    axios.delete(URL + '/' + idPaciente)
    .then(function (response) {
        alert(response.data.message);
    })
    .catch(function(err) {
        alert("Ocorreu o erro "+err+" durante a exclusão do paciente. Tente novamente!");
    })
}

