using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PassaroBLL
    {
        public void Inserir(PassaroDTO pPassaro)
        {
            try 
            {
                PassaroDAL ObjetoDAL = new PassaroDAL();
                List<PassaroDTO> lLista = new List<PassaroDTO>();
                lLista = ObjetoDAL.ListarPorNome(pPassaro);
                if (lLista.Count > 0) 
                {
                    throw new Exception("Nome já consta na lista!");
                } 
                else 
                {
                    ObjetoDAL.Inserir(pPassaro);
                }
            }
                catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(PassaroDTO pPassaro)
        {
            try 
            {
                PassaroDAL ObjetoDAL = new PassaroDAL();
                List<PassaroDTO> lLista = new List<PassaroDTO>();
                lLista = ObjetoDAL.ListarPorNome(pPassaro);
                if (lLista.Count > 0) 
                {
                    throw new Exception("Nome já consta na lista!");
                } 
                else 
                {
                    ObjetoDAL.Alterar(pPassaro);
                }
            }
                catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(PassaroDTO pPassaro)
        {
            try 
            {
                PassaroDAL ObjetoDAL = new PassaroDAL();
                 ObjetoDAL.Excluir(pPassaro);
            }
                catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<PassaroDTO>Listar()
        {
            try 
            {
                PassaroDAL ObjetoDAL = new PassaroDAL();
                return ObjetoDAL.Listar();
            }
                catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
