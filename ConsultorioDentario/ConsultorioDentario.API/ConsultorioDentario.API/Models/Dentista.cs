using System.Collections.Generic;

namespace ConsultorioDentario.API.Models
{
    public class Dentista
    {
        public int id_dentista {get; set;}
        public string Nome {get; set;}
        public string CPF {get; set;}
        public string matricula {get; set;}

        public int id_endereco {get; set;}
        public virtual Endereco Endereco {get; set;}

        public virtual ICollection<Consulta> Consultas { get; set; }

    }
}