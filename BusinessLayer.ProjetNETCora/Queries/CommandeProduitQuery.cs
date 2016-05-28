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
    /// QUERY pour récupérer des entités de types CommandeProduit
    /// </summary>
    public class CommandeProduitQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CommandeProduitQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les produits
        /// </summary>
        /// <returns>IQueryable de CommandeProduit</returns>
        public IQueryable<CommandeProduit> GetAll()
        {
            return _contexte.CommandesProduits;
        }

        /// <summary>
        /// Récupérer un produit par son ID
        /// </summary>
        /// <param name="id">Identifiant du produit à récupérer</param>
        /// <returns>IQueryable de CommandeProduit</returns>
        public IQueryable<CommandeProduit> GetByID(int id, int id2)
        {
            return _contexte.CommandesProduits.Where(p => p.ProduitId == id && p.CommandeId == id2);
        }
    }
}
