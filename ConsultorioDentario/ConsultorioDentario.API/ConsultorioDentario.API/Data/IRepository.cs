using ConsultorioDentario.API.Models;

namespace ConsultorioDentario.API.Data
{
    public interface IRepository
    {
         #region Generics
         void Inserir<T>(T entity) where T : class;
         void Alterar<T>(T entity) where T : class;
         void Excluir<T>(T entity) where T : class;
         bool Salvar();
          #endregion

        #region Classe Paciente
         Paciente[] GetPacientes();
         Paciente GetPacientePorID(int idPaciente);
         Paciente GetPacientePorNome(string nome);
         #endregion
    
        #region Classe Dentista
         Dentista[] GetDentistas();
         Dentista GetDentistaPorID(int idDentista);
         Dentista GetDentistaPorNome(string nome);
        #endregion

        #region Classe Procedimento
        Procedimento[] GetProcedimentos();
         Procedimento GetProcedimentoPorID(int idProcedimento);
         Procedimento GetProcedimentoPorNome(string procedimento);
        #endregion

        #region Classe Consulta
         Consulta[] GetConsultas();
         Consulta GetConsultaPorID(int idConsulta);
        //  Consulta GetConsultaPorNome(string nome);
        #endregion
    }
}