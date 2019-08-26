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
        static string arquivo = "chat.txt";
        static void Main(string[] args)
        {
            //é um saco ter que digitar isso toda vez, entao vo deixar o arquivo como fixo
            //pelo que eu testei nao da nenhum problema abrir o mesmo arquivo mais de 1x
            //entao basta clicar que ele vai gerar o txt e pronto.

            //Console.WriteLine("Digite o caminho para o arquivo");
            //Console.WriteLine(@"Exemplo: caminho\arquivo.bin");

            //arquivo = Console.ReadLine();

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

            AtualizarChat();
        }

        static public void AtualizarChat()
        {
            do
            {
                if (File.Exists(arquivo))
                {
                    try
                    {
                        StreamReader rd = new StreamReader(arquivo);
                        string chat = rd.ReadToEnd();
                        int qtdAtual = chat.Length;
                        if (chatLength < qtdAtual)
                        {
                            chatLength = qtdAtual;
                            Console.Clear();
                            Console.Write("Logado como: " + nome + " | Digite ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("logout");
                            Console.ResetColor();
                            Console.WriteLine(" para fechar o chat.");
                            Console.WriteLine("");
                            Console.WriteLine(chat);
                            
                        }
                        
                        rd.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
                if (mensagem != "")
                {
                    EnviarMensagem();
                }

                if (Console.KeyAvailable)
                {
                    Gravar();
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }

            } while (true);
        }

        static public void EnviarMensagem()
        {
            Console.Write("Mensagem: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            mensagem = Console.ReadLine();

            if (mensagem == "logout")
            {
                Environment.Exit(1);
            }
            else
            {
                Gravar();
            }
        }

        static public void Gravar()
        {
            try
            {
                StreamWriter sw = new StreamWriter(arquivo, true);

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
