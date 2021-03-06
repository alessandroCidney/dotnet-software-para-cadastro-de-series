using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            // Você não pode instanciar uma classe abstrata
            // EntidadeBase minhaClasse = new EntidadeBase();

            // Para isso, você deve instanciar uma classe filha da classe abstrata
            // Serie minhaSerie = new Serie();

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Listagem de Séries");
            Console.WriteLine("------------------------------");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            } 

            foreach (var serie in lista)
            {
                string serieExcluida;

                if(serie.retornaExcluido())
                {
                    serieExcluida = "(EXCLUÍDA)";
                } else {
                    serieExcluida = "";
                }

                Console.WriteLine("#ID {0}: - {1}  {2}", serie.retornaId(), serie.retornaTitulo(), serieExcluida);   
            }
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Inserção de Séries");
            Console.WriteLine("------------------------------");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Insere(novaSerie);
            Console.Clear();
        }

        private static void ExcluirSerie()
        {
            int opcaoEscolhida;
            
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Exclusão de Séries");
            Console.WriteLine("------------------------------");

            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Deseja mesmo excluir a série de ID {0}?", indiceSerie);
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");

            opcaoEscolhida = int.Parse(Console.ReadLine());

            switch (opcaoEscolhida)
            {
                case 1:
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine("Série Excluída");
                    break;

                case 2:
                    Console.WriteLine("Retornando ao menu de opções...");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("   Visualização de Séries");
            Console.WriteLine("------------------------------");

            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine();
            
            Console.WriteLine(serie);
            
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("    Atualização de Séries");
            Console.WriteLine("------------------------------");

            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("                Bem vindo ao Console Séries!");
            Console.WriteLine("       Salvamos as suas séries de forma rápida e segura");
            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
