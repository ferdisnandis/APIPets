using Pets.Context;
using Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repositories
{
    public class TipoPetRepostory : ITipoPet
    {
        PetsContext conexao = new PetsContext();
        SqlCommand cmd = new SqlCommand();

        public TipoPet Alterar(int id, TipoPet tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoPet SET " +
                "Especie = @tipoPet, " +
                "WHERE IdEspecie = @IdTP";
            cmd.Parameters.AddWithValue("@IdTP", tp.IdEspecie);
                cmd.Parameters.AddWithValue("@tipoPet", tp.Especie);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
            return tp;

        }

        public TipoPet BuscarId(int IdTipoPet)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM WHERE IdTipoPet = @idTP";
            cmd.Parameters.AddWithValue("@idTP", IdTipoPet);
            SqlDataReader dados = cmd.ExecuteReader();
            TipoPet tp = new TipoPet();
            while (dados.Read())
            {
                tp.IdEspecie = Convert.ToInt32(dados.GetValue(0));
                tp.Especie = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return tp;
        }

        public TipoPet Cadastrar(TipoPet tp)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "INSERT INTO TipoPet " +
                " (Especie) ";
            " VALUES " +
                " (@TipoPet) ";
            cmd.Parameters.AddWithValue("@TipoPet", tp.Especie);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return tp;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoPet WHERE IdTipoPet = @idTP";
            cmd.Parameters.AddWithValue("@idTP", id);
            conexao.Desconectar();
        }

        public List<TipoPet> ListarTodosPet()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TIPOPET";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoPet> tp = new List<TipoPet>();
            while (dados.Read())
            {
                tp.Add(
                    new TipoPet()
                    {
                        IdEspecie = Convert.ToInt32(dados.GetValue(0)),
                        Especie = (string)dados.GetValue(1),
                    }
                );
            }
            conexao.Desconectar();
            return tp;
        }
    }
}
