using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaPassaro
{
    class Program
    {
        static void Main(string[] args)
        {
            string comando = "";
            while (comando != "4")
            {
                try 
                {
                    PassaroBLL lObjetoBLL = new PassaroBLL();
                    Console.Clear();
                    ExibePassaros();
                    Console.WriteLine("");
                    Console.WriteLine("Digite a ação desejada 1- inserir; 2- Alterar; 3- Excluir; 4 - Sair");

                    comando= Console.ReadLine();

                    if (comando == "1") 
                    {
                        Console.WriteLine("Digite o nome desejado");
                        string descricaoPassaro = Console.ReadLine();
                        PassaroDTO passaro = new PassaroDTO(descricaoPassaro);

                        lObjetoBLL.Inserir(passaro);

                        Console.Clear();
                        ExibePassaros();
                        Console.WriteLine("Inserido com sucesso!");
                        Console.WriteLine("Aperte enter para sair");
                    }
                    else if (comando == "2") 
                    {
                        Console.WriteLine("Digite o id desejado para alterar");
                        string idPassaro = Console.ReadLine();
                        Console.WriteLine("Digite o nome a ser alterado");
                        string descricaoPassaro = Console.ReadLine();
                        PassaroDTO passaro = new PassaroDTO(descricaoPassaro);
                        passaro.Id = Convert.ToInt32(idPassaro);
                        lObjetoBLL.Alterar(passaro);

                        Console.Clear();
                        ExibePassaros();
                        Console.WriteLine(descricaoPassaro + "Excluido com sucesso!");
                        Console.WriteLine("Aperte enter para sair");
                    }  
                    else if(comando == "3") 
                    {
                        Console.WriteLine("Digite o id desejado para alterar");
                        string idPassaro = Console.ReadLine();
                        PassaroDTO passaro = new PassaroDTO(idPassaro);
                        passaro.Id = Convert.ToInt32(idPassaro);
                        lObjetoBLL.Excluir(passaro);

                        Console.Clear();
                        ExibePassaros();
                        Console.WriteLine("Excluido com sucesso!");
                        Console.WriteLine("Aperte enter para sair");
                    }  
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro : "+ ex.Message);
                }
            }
        }
        public static void ExibePassaros()
        {
              Console.WriteLine("Lista de Passaros Cadastrados!");
              List<PassaroDTO> lista = new List<PassaroDTO>();
              PassaroBLL objetoBLL = new PassaroBLL();
              lista = objetoBLL.Listar();
              foreach(var item in lista)
              {
                  Console.WriteLine("Passaro: " + item.Id.ToString ()+ "-"+ item.Descricao);
              }
        }
    }
}
