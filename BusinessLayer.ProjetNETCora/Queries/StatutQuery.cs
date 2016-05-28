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
    /// QUERY pour récupérer des entités de types Statut
    /// </summary>
    public class StatutQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public StatutQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les statuts
        /// </summary>
        /// <returns>IQueryable de Statut</returns>
        public IQueryable<Statut> GetAll()
        {
            return _contexte.Statuts;
        }

        /// <summary>
        /// Récupérer un statut par son ID
        /// </summary>
        /// <param name="id">Identifiant du statut à récupérer</param>
        /// <returns>IQueryable de Statut</returns>
        public IQueryable<Statut> GetByID(int id)
        {
            return _contexte.Statuts.Where(p => p.Id == id);
        }
    }
}
