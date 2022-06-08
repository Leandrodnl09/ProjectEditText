using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Para novo arquivo");
            Console.WriteLine("0 - Para sair");
            Console.WriteLine("-----------------------------");
            short opition = short.Parse(Console.ReadLine());

            switch (opition)
            {
                case 0: Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))  //Sempre que for ler ou salvalr um arquivo usar o using
            {
                string text = file.ReadToEnd();//Ler um texto ate o final
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();   
        }
        
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite su texto abaixo, (ESC para sair)");
            Console.WriteLine("-----------------------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
            
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) //using vai abrir e fechar o arquivo automaticamente.
            {
                file.Write(text); //Esse using serve para criar um texte e salvar 
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}