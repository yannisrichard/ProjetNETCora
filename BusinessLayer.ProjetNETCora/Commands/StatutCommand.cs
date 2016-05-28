using Modele.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjetNETCora.Commands
{
    /// <summary>
    /// COMMAND pour ajouter / modifier et supprimer un statut
    /// </summary>
    public class StatutCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public StatutCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter le statut en base à partir du contexte
        /// </summary>
        /// <param name="s">Statut à ajouter</param>
        /// <returns>Identifiant du statut ajouté</returns>
        public int Ajouter(Statut s)
        {
            _contexte.Statuts.Add(s);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un statut déjà présent en base à partir du cotnexte
        /// </summary>
        /// <param name="s">Statut à modifier</param>
        public void Modifier(Statut s)
        {
            Statut upSta = _contexte.Statuts.Where(sta => sta.Id == s.Id).FirstOrDefault();
            if (upSta != null)
            {
                upSta.Libelle = s.Libelle;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un statut en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="statutID">Identifiant du statut à supprimer</param>
        public void Supprimer(int statutID)
        {
            Statut delSta = _contexte.Statuts.Where(sta => sta.Id == statutID).FirstOrDefault();
            if (delSta != null)
            {
                _contexte.Statuts.Remove(delSta);
            }
            _contexte.SaveChanges();
        }
    }
}
