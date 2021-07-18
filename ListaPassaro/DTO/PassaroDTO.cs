using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PassaroDTO
    {
        public PassaroDTO() 
        {

        }
        public PassaroDTO(string pDescricao)
        {
            Descricao = pDescricao;
        }
        public int Id{ get;set; }
        public string Descricao{ get;set; }
    }
}
