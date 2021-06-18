using System;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            // Você não pode instanciar uma classe abstrata
            // EntidadeBase minhaClasse = new EntidadeBase();

            // Para isso, você deve instanciar uma classe filha da classe abstrata
            // Serie minhaSerie = new Serie();

            Serie newObjeto = new Serie();

            Console.WriteLine("Hello World!");
        }
    }
}
