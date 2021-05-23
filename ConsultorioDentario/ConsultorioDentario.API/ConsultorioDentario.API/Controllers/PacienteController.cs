using System;
using System.Collections.Generic;
using ConsultorioDentario.API.Data;
using ConsultorioDentario.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioDentario.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IRepository _repo;
        public PacienteController(IRepository repo){
            _repo = repo;
        }
      
        [HttpGet]
        public IActionResult Get(){
            try{
                var result = _repo.GetPacientes();

                if(result != null)
                    return Ok(result);
                return BadRequest("Não foi póssivel carregar a lista de pacientes. Tente novamente!");
            
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");   
            }
        }

      
        [HttpGet("PacientePorID/{idPaciente}")]
        public IActionResult GetPacientePorID(int idPaciente){
             try
            {
                var result = _repo.GetPacientePorID(idPaciente);
                
                if(result != null)
                    return Ok(result);
                return BadRequest("Paciente não encontrado. Tente novamente!");
            
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("IDPacienteParaConsulta/{idPaciente}")]
        public int GetIDPacienteParaConsulta(int idPaciente)
        {
            int vInicial = 0;
          
                var result = _repo.GetPacientePorID(idPaciente);

                if (result != null)
                    return result.id_paciente;
                return vInicial;
        }




        [HttpGet("PacientePorNome/{nomePaciente}")]
        public IActionResult GetPacientePorNome(string nomePaciente){
             try
            {
                var result = _repo.GetPacientePorNome(nomePaciente);

                if (result != null)
                    return Ok(result);
                return BadRequest("Paciente não encontrado. Tente novamente!");

            }
            catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }


            

        }

        [HttpPost]
        public  IActionResult post(Paciente paciente){
             try
            {
                 _repo.Inserir(paciente);
            }
            catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }

            
            if (_repo.Salvar())
            {
                return Ok(new { message = "Paciente cadastrado com sucesso!" });
            }

            return BadRequest();
        }

        [HttpPut("{idPaciente}")]
        public IActionResult put(int idPaciente, Paciente paciente){
             try
            {
                var result = _repo.GetPacientePorID(idPaciente);

                if (result == null) {
                    return BadRequest("Paciente não encontrado. Tente novamente!");

                } else
                {
                    if(result.id_paciente == paciente.id_paciente)
                        _repo.Alterar(paciente);
                   
                    if (_repo.Salvar())
                        return Ok(paciente);

                }
            }
            catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

     
        [HttpDelete("{idPaciente}")]
        public IActionResult delete(int idPaciente){
             try
            {
               var result = _repo.GetPacientePorID(idPaciente);
               
               if(result == null)
                    return BadRequest("Paciente não encontrado. Tente novamente!");
                _repo.Excluir(result);

                if(_repo.Salvar())
                    return Ok(new {message = "Paciente excluído com sucesso!"});

                return BadRequest("Paciente não excluído. Tente novamente!");
                
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

        }
    }
}