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
    /// QUERY pour récupérer des entités de types Commande
    /// </summary>
    public class CommandeQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CommandeQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les commandes
        /// </summary>
        /// <returns>IQueryable de Commande</returns>
        public IQueryable<Commande> GetAll()
        {
            return _contexte.Commandes;
        }

        /// <summary>
        /// Récupérer un commande par son ID
        /// </summary>
        /// <param name="id">Identifiant du commande à récupérer</param>
        /// <returns>IQueryable de Commande</returns>
        public IQueryable<Commande> GetByID(int id)
        {
            return _contexte.Commandes.Where(p => p.Id == id);
        }
    }
}
