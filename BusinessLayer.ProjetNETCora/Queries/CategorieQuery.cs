using Modele.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjetNETCora.Queries
{
    /// <summary>
    /// QUERY pour récupérer des entités de types Categorie
    /// </summary>
    public class CategorieQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CategorieQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les categories
        /// </summary>
        /// <returns>IQueryable de Categorie</returns>
        public IQueryable<Categorie> GetAll()
        {
            return _contexte.Categories;
        }

        /// <summary>
        /// Récupérer un categorie par son ID
        /// </summary>
        /// <param name="id">Identifiant du categorie à récupérer</param>
        /// <returns>IQueryable de Categorie</returns>
        public IQueryable<Categorie> GetByID(int id)
        {
            return _contexte.Categories.Where(p => p.Id == id);
        }
    }
}
