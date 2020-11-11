using System;
using ConsultorioDentario.API.Data;
using ConsultorioDentario.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioDentario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedimentoController : ControllerBase
    {
        private readonly IRepository _repo;
        public ProcedimentoController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(){
            try{
                var result = _repo.GetProcedimentos();

                if(result != null)
                    return Ok(result);
                return BadRequest("Não foi póssivel carregar a lista de procedimentos. Tente novamente!");
            
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");   
            }
        }

        [HttpGet("ProcedimentoPorID/{idProcedimento}")]
        public IActionResult GetProcedimentoPorID(int idProcedimento){
             try
            {
                var result = _repo.GetProcedimentoPorID(idProcedimento);
                
                if(result != null)
                    return Ok(result);
                return BadRequest("Procedimento não encontrado. Tente novamente!");
            
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // [HttpGet("ProcedimentoPorNome/{nomeProcedimento}")]
        // public IActionResult GetProcedimentoPorNome(string nomeProcedimento){
        //      try
        //     {
        //         var result = _repo.GetProcedimentoPorNome(nomeProcedimento);
                
        //         if(result != null)
        //             return Ok(result);
        //         return BadRequest("Procedimento não encontrado. Tente novamente!");
            
        //     }catch(Exception ex){
                
        //         return BadRequest($"Erro: {ex.Message}");
        //     }
        // }

        [HttpPost]
        public IActionResult post(Procedimento procedimento){
             try
            {
              _repo.Inserir(procedimento);
              
              if(_repo.Salvar()){
                  return Ok(new {message = "Procedimento cadastrado com sucesso!"});
              }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    
    
        [HttpPut("{idProcedimento}")]
        public IActionResult put(int idProcedimento, Procedimento procedimento){
             try
            {
                var result = _repo.GetProcedimentoPorID(idProcedimento);

                if(result == null)
                    return BadRequest("Procedimento não encontrado. Tente novamente!");

                _repo.Alterar(procedimento);

                if(_repo.Salvar())
                    return Ok(procedimento);
              
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    
        [HttpDelete("{idProcedimento}")]
        public IActionResult delete(int idProcedimento){
             try
            {
               var result = _repo.GetProcedimentoPorID(idProcedimento);
               
               if(result == null)
                    return BadRequest("Procedimento não encontrado. Tente novamente!");
                _repo.Excluir(result);

                if(_repo.Salvar())
                    return Ok(new {message = "Procedimento excluído com sucesso!"});

                return BadRequest("Procedimento não excluído. Tente novamente!");
                
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

        }
    }
}