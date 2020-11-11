using System;
using System.Collections.Generic;

namespace ConsultorioDentario.API.Models
{
    public class Paciente
    {
       
        public int id_paciente {get; set;}

        public string Nome {get; set;}
        public string CPF {get; set;}
        public DateTime dt_nascimento {get; set;}
        public string numCarteira {get; set;}
        public DateTime dt_cadastro {get; set;}

       
        public int id_endereco {get; set;}
        public virtual Endereco Endereco {get; set;}

        public ICollection<Consulta> Consulta {get; set;}






    }
}