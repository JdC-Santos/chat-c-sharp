using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryChat
{
    class Program
    {
        static string nome = "";
        static string mensagem;
        static int NomeLength;
        static int chatLength = 0;
        static void Main(string[] args)
        {
            string arquivo = "";

            //é um saco ter que digitar isso toda vez, entao vo deixar o arquivo como fixo
            //pelo que eu testei nao da nenhum problema abrir o mesmo arquivo mais de 1x
            //entao basta clicar que ele vai gerar o txt e pronto.

            //Console.WriteLine("Digite o caminho para o arquivo");
            //Console.WriteLine(@"Exemplo: caminho\arquivo.bin");

            //arquivo = Console.ReadLine();
            arquivo = "chat.txt";

            Console.Write("Digite o seu nick: ");
            nome = Console.ReadLine();

            NomeLength = nome.Length + 4;

            if (!File.Exists(arquivo))
            {
                StreamWriter st = new StreamWriter(arquivo, true);
               
                st.Write("[System]: ");
                st.Write("--- Bem vindo ---\n");

                st.Close();
            }

            AtualizarChat(arquivo);
        }

        static public void AtualizarChat(string caminho)
        {
            do
            {
                if (File.Exists(caminho))
                {
                    try
                    {
                        StreamReader rd = new StreamReader(caminho);
                        string chat = rd.ReadToEnd();
                        int qtdAtual = chat.Length;
                        if (chatLength < qtdAtual)
                        {
                            chatLength = qtdAtual;
                            Console.Clear();
                            Console.WriteLine(chat);
                            
                        }
                        
                        rd.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }

                if (Console.KeyAvailable)
                {
                    Gravar(caminho);
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }

            } while (true);
        }

        static public void Gravar(string caminho)
        {
            try
            {
                StreamWriter sw = new StreamWriter(caminho, true);

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                mensagem = Console.ReadLine();

                Console.ResetColor();

                sw.Write("[" + nome + "]: ");
                sw.Write(mensagem + "\n");
                mensagem = "";
                sw.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
