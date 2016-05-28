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
    /// QUERY pour récupérer des entités de types LogProduit
    /// </summary>
    public class LogProduitQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public LogProduitQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les logproduits
        /// </summary>
        /// <returns>IQueryable de LogProduit</returns>
        public IQueryable<LogProduit> GetAll()
        {
            return _contexte.LogProduits;
        }

        /// <summary>
        /// Récupérer un logproduit par son ID
        /// </summary>
        /// <param name="id">Identifiant du logproduit à récupérer</param>
        /// <returns>IQueryable de LogProduit</returns>
        public IQueryable<LogProduit> GetByID(int id)
        {
            return _contexte.LogProduits.Where(p => p.Id == id);
        }
    }
}
