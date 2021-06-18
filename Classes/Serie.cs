using System;

namespace Series
{
    // Classe que herda da EntidadeBase
    public class Series : EntidadeBase
    {
        // Atributos

        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        // Reescrevendo o método ToString()
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Enviroment.NewLine;
            retorno += "Titulo: " + this.Titulo + Enviroment.NewLine;
            retorno += "Descrição: " + this.Descricao + Enviroment.NewLine;
            retorno += "Ano de início: " + this.Ano;

            return retorno;
        }

        // Métodos de encapsulamento

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
    }
}