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
    /// QUERY pour récupérer des entités de types Client
    /// </summary>
    public class ClientQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public ClientQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les clients
        /// </summary>
        /// <returns>IQueryable de Categorie</returns>
        public IQueryable<Client> GetAll()
        {
            return _contexte.Clients;
        }

        /// <summary>
        /// Récupérer un client par son ID
        /// </summary>
        /// <param name="id">Identifiant du client à récupérer</param>
        /// <returns>IQueryable de Categorie</returns>
        public IQueryable<Client> GetByID(int id)
        {
            return _contexte.Clients.Where(p => p.Id == id);
        }
    }
}
