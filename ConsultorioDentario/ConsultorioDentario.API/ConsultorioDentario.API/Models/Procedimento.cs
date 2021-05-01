using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioDentario.API.Models
{
    public class Procedimento
    {
        public int id_procedimento {get; set;}
        public string Nome {get; set;}
        public int duracao {get; set;}
        public string valor {get; set;}

         public virtual ICollection<Consulta> Consultas { get; set; }
    }
}