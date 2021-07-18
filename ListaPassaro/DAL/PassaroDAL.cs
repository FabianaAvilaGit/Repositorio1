using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PassaroDAL
    {
        SqlConnection conexao = new SqlConnection();
    
        public SqlConnection Conectar()
        {
            conexao.ConnectionString = "Data Source=DESKTOP-64C6O6T\\SQLEXPRESS;Initial Catalog=ListaPassaros;User ID=sa;Password=senha";
            if(conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }
            return conexao;
        }
        public void Desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        public void Inserir(PassaroDTO pPassaro) 
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Conectar();
                cmd.CommandText = "insert into tbPassaros (descricao) values ('" +pPassaro.Descricao+ "')";
                cmd.ExecuteNonQuery();
                Desconectar();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public void Alterar(PassaroDTO pPassaro) 
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Conectar();
                cmd.CommandText = "update tbPassaros set descricao = '" +pPassaro.Descricao + "'where id = " + pPassaro.Id.ToString();
                cmd.ExecuteNonQuery();
                Desconectar();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public void Excluir(PassaroDTO pPassaro) 
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Conectar();
                cmd.CommandText = "detete from tbPassaros where id = " + pPassaro.Id.ToString();
                cmd.ExecuteNonQuery();
                Desconectar();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public List<PassaroDTO> Listar()
        {   
            List<PassaroDTO>lListaPassaro = new List<PassaroDTO>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Conectar();
                cmd.CommandText = "select * from tbPassaros";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        PassaroDTO obj = new PassaroDTO();
                        obj.Id = Convert.ToInt32(dr[0].ToString());
                        obj.Descricao =(dr[1].ToString());
                        lListaPassaro.Add(obj);
                    }
                }
                Desconectar();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return lListaPassaro;
        }
        public List<PassaroDTO> ListarPorNome(PassaroDTO pPassaro)
        {   
            List<PassaroDTO>lListaPassaro = new List<PassaroDTO>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Conectar();
                cmd.CommandText = "select id, descricao from tbPassaros where descricao = '" + pPassaro.Descricao + "'and id <>" +pPassaro.Id.ToString();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        PassaroDTO obj = new PassaroDTO();
                        obj.Id = Convert.ToInt32(dr[0].ToString());
                        obj.Descricao =(dr[1].ToString());
                        lListaPassaro.Add(obj);
                    }
                }
                Desconectar();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return lListaPassaro;
        }
    }
}
