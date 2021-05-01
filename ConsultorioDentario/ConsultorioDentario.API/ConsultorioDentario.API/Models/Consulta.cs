using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioDentario.API.Models
{
    public class Consulta
    {
        public int id_consulta {get; set;}
        public DateTime dt_consulta {get; set;}
        public string observacao {get; set;}

        public int? id_paciente { get; set; }
        public virtual Paciente Paciente { get; set; }
        
        public int? id_procedimento { get; set; }
        public virtual Procedimento Procedimento { get; set; }

       

        public int id_dentista { get; set; }
        public virtual Dentista Dentista { get; set; }

    }
}