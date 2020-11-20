using System;
using ConsultorioDentario.API.Data;
using ConsultorioDentario.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioDentario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class DentistaController : ControllerBase
    {
        private readonly IRepository _repo;
        public DentistaController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(){
            try{
                var result = _repo.GetDentistas();
                
                if(result != null)
                    return Ok(result);
                return BadRequest("Não foi póssivel carregar a lista de dentistas. Tente novamente!");
            

            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");   
            }
        }

        [HttpGet("DentistaPorID/{idDentista}")]
        public IActionResult GetDentistaPorID(int idDentista){
             try
            {
                var result = _repo.GetDentistaPorID(idDentista);
                if(result != null)
                    return Ok(result);
                return BadRequest("Dentista não encontrado. Tente novamente!");
            
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("DentistaPorNome/{nome}")]
        public IActionResult GetDentistaPorNome(string nome){
             try
            {
                var result = _repo.GetDentistaPorNome(nome);
                
                if(result != null)
                    return Ok(result);
                return BadRequest("Dentista não encontrado. Tente novamente!");
            
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult post(Dentista dentista){
             try
            {
              _repo.Inserir(dentista);
              
              if(_repo.Salvar()){
                 return Ok(new {message = "Dentista cadastrado com sucesso!"});
              }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    
    
        [HttpPut("{idDentista}")]
        public IActionResult put(int idDentista, Dentista dentista){
             try
            {
                var result = _repo.GetDentistaPorID(idDentista);

                if(result == null)
                    return BadRequest("Dentista não encontrado. Tente novamente!");

                _repo.Alterar(dentista);

                if(_repo.Salvar())
                    return Ok(dentista);
              
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    
        [HttpDelete("{idDentista}")]
        public IActionResult delete(int idDentista){
             try
            {
               var result = _repo.GetDentistaPorID(idDentista);
               
               if(result == null)
                    return BadRequest("Dentista não encontrado. Tente novamente!");

                _repo.Excluir(result);

                if(_repo.Salvar())
                    return Ok(new {message = "Dentista excluído com sucesso!"});

                return Ok("Dentita não excluído. Tente novamente!");
                
            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}