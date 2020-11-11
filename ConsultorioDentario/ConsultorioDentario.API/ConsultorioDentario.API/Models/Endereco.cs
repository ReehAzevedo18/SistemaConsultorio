namespace ConsultorioDentario.API.Models
{
    public class Endereco
    {
         public int id_endereco {get; set;}
         public string logradouro {get; set;}
         public int num {get; set;}
         public string complemento {get; set;}
         public string bairro {get; set;}
         public string cidade {get; set;}

         public Paciente Paciente {get; set;}

         public Dentista Dentista {get; set;}
    }
}