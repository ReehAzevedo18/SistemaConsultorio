using System.Linq;
using ConsultorioDentario.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioDentario.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
             _context = context;
        }

        #region CRUD
        public void Inserir<T>(T entity) where T : class
        {
          
         _context.Add(entity);
        }

        public void Alterar<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
        }

        public void Excluir<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }
        
        public bool Salvar()
        {
            
           return (_context.SaveChanges() > 0);
        }
        #endregion

        #region Paciente

        public Paciente GetPacientePorID(int idPaciente)
        {
            IQueryable<Paciente> query = _context.Paciente;

            query = query.Include(a => a.Endereco);

            query = query.AsNoTracking()
                         .OrderBy(a => a.id_paciente)
                         .Where(paciente => paciente.id_paciente == idPaciente);

          return query.FirstOrDefault();
        }

        public Paciente GetPacientePorNome(string nomePaciente)
        {
            IQueryable<Paciente> query = _context.Paciente.Where(p => p.Nome.Contains(nomePaciente));

            foreach (var q in query){
              if(q.Nome.Contains(nomePaciente)){
                 query = query.Include(a => a.Endereco);
                
              }
                
            }
             return query.FirstOrDefault();
           
        }

         public Paciente[] GetPacientes()
        {
          IQueryable<Paciente> query = _context.Paciente;

           query = query.AsNoTracking().OrderBy(a => a.id_paciente);

           return query.ToArray();
        }
        #endregion

        #region Dentista
        public Dentista[] GetDentistas()
        {
          IQueryable<Dentista> query = _context.Dentista;

           query = query.AsNoTracking().OrderBy(a => a.id_dentista);

           return query.ToArray();
        }
        
        public Dentista GetDentistaPorID(int idDentista)
        {
            IQueryable<Dentista> query = _context.Dentista;

            query = query.Include(a => a.Endereco);

            query = query.AsNoTracking()
                         .OrderBy(a => a.id_dentista)
                         .Where(d => d.id_dentista == idDentista);

          return query.FirstOrDefault();
        }

          public Dentista GetDentistaPorNome(string nome)
        {
            IQueryable<Dentista> query = _context.Dentista.Where(p => p.Nome.Contains(nome));


            foreach(var q in query){
              if(q.Nome.Contains(nome)){
                 query = query.Include(a => a.Endereco);                
              }                
            }

             return query.FirstOrDefault();
        }

         
 
        #endregion
    
        #region Procedimento
            public Procedimento GetProcedimentoPorID(int idProcedimento)
        {
            IQueryable<Procedimento> query = _context.Procedimento;

            query = query.AsNoTracking()
                         .OrderBy(a => a.id_procedimento)
                         .Where(p => p.id_procedimento == idProcedimento);

          return query.FirstOrDefault();
        }

         public Procedimento[] GetProcedimentos()
        {
          IQueryable<Procedimento> query = _context.Procedimento;

           query = query.AsNoTracking().OrderBy(a => a.id_procedimento);

           return query.ToArray();
        }

           public Procedimento GetProcedimentoPorNome(string procedimento)
        {
            IQueryable<Procedimento> query = _context.Procedimento.Where(p => p.Nome.Contains(procedimento));


            foreach(var q in query){
                q.Nome.Contains(procedimento);
            }
             return query.FirstOrDefault();
           
        }
        #endregion
    
        #region Consulta
           public Consulta GetConsultaPorID(int idConsulta)
        {
            IQueryable<Consulta> query = _context.Consulta;

            query = query.Include(d => d.Dentista)
                          .Include(a => a.Paciente)
                          .Include(p => p.Procedimento);

            query = query.AsNoTracking()
                         .OrderBy(a => a.id_consulta)
                         .Where(con => con.id_consulta == idConsulta);

          return query.FirstOrDefault();
        }

        // public Paciente GetConsultaPorNome(string nome)
        // {
        //     IQueryable<Consulta> query = _context.Consulta.Where(p => p.Nome.Contains(nome));


        //     foreach(var q in query){
        //       if(q.Nome.Contains(nome)){
        //          query = query.Include(d => d.Dentista)
        //                   .Include(a => a.Paciente)
        //                   .Include(p => p.Procedimento);                
        //       }
                
        //     }
        //      return query.FirstOrDefault();
           
        // }


         public Consulta[] GetConsultas()
        {
          IQueryable<Consulta> query = _context.Consulta;

           query = query.AsNoTracking().OrderBy(a => a.id_consulta);

           return query.ToArray();
        }
        #endregion
    }
}