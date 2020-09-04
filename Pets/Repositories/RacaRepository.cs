using Pets.Context;
using Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repositories
{
    public class RacaRepository : IRaca
    {
        PetsContext conexao = new PetsContext();
        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca" +
                "SET RacaVet = @racaVet" +
                "WHERE IdRaca = @idR";

            cmd.Parameters.AddWithValue("@idR", r.IdRaca);
            cmd.Parameters.AddWithValue("@racaVet", r.RacaVet);

            conexao.Desconectar();

            return r;
        }

        public Raca BuscarId(int IdRaca)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM WHERE IdRaca = @idR";
            cmd.Parameters.AddWithValue("@idR", IdRaca);

            SqlDataReader dados = cmd.ExecuteReader();
            Raca r = new Raca();
            while(dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.RacaVet = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return r;
            
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "INSERT INTO Raca " +
                " (RacaVet) ";
            " VALUES " +
                " (@racaVet) ";
            cmd.Parameters.AddWithValue("@racaVet", r.RacaVet);
            cmd.Parameters.AddWithValue("@IdR", r.IdRaca);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return r;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Raca> ListarTodosRaça()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM ALUNO";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();
            while(dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        RacaVet = (string)dados.GetValue(1),
                    }
                );
            }
            conexao.Desconectar();
            return racas;
            
        }
    }
}
