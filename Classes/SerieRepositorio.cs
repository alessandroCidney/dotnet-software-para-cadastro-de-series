using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    // Implementa um repositório de séries
    public class SerieRepositorio : IRepositorio<Serie>
    {
        // Lista de séries
        public List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            // Poderíamos usar RemoveAt(), mas isso reclassificaria os próximos itens da lista

            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}