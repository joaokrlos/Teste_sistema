using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Cadastro_Sistema.Models
{
    public class FuncionarioDAL : IFuncionarioDAL
    {
        string connectionString = @"Data Source=Joao;Initial Catalog=CadastroDB;Integrated Security=True;";
        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario> Istfuncionario = new List<Funcionario>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FuncionarioId,Nome,Idade,Genero From Funcionario", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Idade = Convert.ToInt32(rdr["Idade"]);
                    funcionario.Genero = rdr["Genero"].ToString();

                    Istfuncionario.Add(funcionario);
                }
                con.Close();
            }
            return Istfuncionario;
        }
        public void AddFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Inser into Funcionario(Nome,Idade,Genero) Values(@Nome,@Idade,@Genero)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Idade", funcionario.Idade);
                cmd.Parameters.AddWithValue("@Genero", funcionario.Genero);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update Funcionario set Nome = @Nome, Idade = @Idade, Genero = @Genero";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@FuncionarioId", funcionario.FuncionarioId);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Idade", funcionario.Idade);
                cmd.Parameters.AddWithValue("@Genero", funcionario.Genero);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        public Funcionario GetFuncionario(int? id)
        {
            Funcionario funcionario = new Funcionario();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Funcionario WHERE FuncionarioId = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Idade = Convert.ToInt32(rdr["Idade"]);
                    funcionario.Genero = rdr["Genero"].ToString();
                }
            }
            return funcionario;

        }
        public void DeleteFuncionario(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete From FuncionarioId = @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@FuncionarioId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
    }
}