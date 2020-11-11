using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ConsultorioDentario.API.Models
{
    public class Consulta
    {
        public int id_consulta {get; set;}
        public DateTime dt_consulta {get; set;}
        public string observacao {get; set;}

        public Dentista Dentista {get; set;}
        
        public Paciente Paciente {get; set;}
      
        public Procedimento Procedimento {get; set;}

    }
}