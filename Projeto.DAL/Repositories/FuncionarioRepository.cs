using Projeto.DAL.Contracts;
using Projeto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Projeto.DAL.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string connectionString;
        public FuncionarioRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;
        }
        public void Insert(Funcionario obj)
        {
            string query = "insert into Funcionario(Nome, Salario, DataAdmissao) values (@Nome, @Salario, @DataAdmissao)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", obj.Nome);
                command.Parameters.AddWithValue("@Salario", obj.Salario);
                command.Parameters.AddWithValue("@DataAdmissao", obj.DataAdmissao);
                command.ExecuteNonQuery();
            }
        }
        public void Update(Funcionario obj)
        {
            string query = "update Funcionario set Nome=@Nome, Salario=@Salario, DataAdmissao=@DataAdmissao where IdFuncionario=@IdFuncionario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdFuncionario", obj.IdFuncionario);
                command.Parameters.AddWithValue("@Nome", obj.Nome);
                command.Parameters.AddWithValue("@Salario", obj.Salario);
                command.Parameters.AddWithValue("@DataAdmissao", obj.DataAdmissao);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            string query = "delete from Funcionario where IdFuncionario=@IdFuncionario";
        }
        public Funcionario SelectById(int id)
        {
            string query = "select * from Funcionario where IdFuncionario=@IdFuncionario";
        }
        public List<Funcionario> SelectAll()
        {
            string query = "select * from Funcionario";
        }
        public List<Funcionario> SelectAll(string nome)
        {
            string query = "select * from Funcionario where Nome like @Nome";
        }
    }
}
