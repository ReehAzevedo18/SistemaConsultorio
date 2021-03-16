using System;
using ConsultorioDentario.API.Data;
using ConsultorioDentario.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioDentario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ConsultaController : ControllerBase
    {
                private readonly IRepository _repo;
        public ConsultaController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(){
            try{
                var result = _repo.GetConsultas();

                if(result != null)
                    return Ok(result);
                return BadRequest("Não foi póssivel carregar a lista de consultas. Tente novamente!");
            
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");   
            }
        }

        [HttpGet("ConsultaPorID/{idConsulta}")]
        public IActionResult GetConsultaPorID(int idConsulta){
             try
            {
                var result = _repo.GetConsultaPorID(idConsulta);
                
                if(result != null)
                    return Ok(result);
                return BadRequest("Consulta não encontrada. Tente novamente!");
            
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        //[HttpGet("ConsultaPorDentista/{nomeDentista}")]
        //public IActionResult GetConsultaPorDentista(string nomeDentista)
        //{
        //    try
        //    {
        //        var result = _repo.GetConsultaPorNome(nomeDentista);

        //        if (result != null)
        //            return Ok(result);
        //        return BadRequest("Consulta não encontrada. Tente novamente!");

        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest($"Erro: {ex.Message}");
        //    }
        //}

        //[HttpGet("ConsultaPorPaciente/{nomePaciente}")]
        //public IActionResult GetConsultaPorPaciente(string nomePaciente)
        //{
        //    try
        //    {
 
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest($"Erro: {ex.Message}");
        //    }
        //}

        [HttpPost]
        public IActionResult post(Consulta consulta){
             try
            {
              _repo.Inserir(consulta);
              
              if(_repo.Salvar()){
                  return Ok(new {message = "Consulta cadastrada com sucesso!"});
              }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    
    
        [HttpPut("{idConsulta}")]
        public IActionResult put(int idConsulta, Consulta consulta){
             try
            {
                var result = _repo.GetConsultaPorID(idConsulta);

                if(result == null)
                    return BadRequest("Consulta não encontrada. Tente novamente!");

                _repo.Alterar(consulta);

                if(_repo.Salvar())
                    return Ok(consulta);
              
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    
        [HttpDelete("{idConsulta}")]
        public IActionResult delete(int idConsulta){
             try
            {
               var result = _repo.GetConsultaPorID(idConsulta);
               
               if(result == null)
                    return BadRequest("Consulta não encontrada. Tente novamente!");
                _repo.Excluir(result);

                if(_repo.Salvar())
                    return Ok(new {message = "Consulta excluída com sucesso!"});

                return BadRequest("Consulta não excluída. Tente novamente!");
                
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

        }
        
    }
}