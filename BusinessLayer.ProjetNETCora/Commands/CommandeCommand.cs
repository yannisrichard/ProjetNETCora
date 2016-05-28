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
    /// COMMAND pour ajouter / modifier et supprimer un commande
    /// </summary>
    public class CommandeCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CommandeCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter le commande en base à partir du contexte
        /// </summary>
        /// <param name="c">Commande à ajouter</param>
        /// <returns>Identifiant du commande ajouté</returns>
        public int Ajouter(Commande c)
        {
            _contexte.Commandes.Add(c);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un commande déjà présent en base à partir du cotnexte
        /// </summary>
        /// <param name="c">Commande à modifier</param>
        public void Modifier(Commande c)
        {
            Commande upCde = _contexte.Commandes.Where(cde => cde.Id == c.Id).FirstOrDefault();
            if (upCde != null)
            {
                upCde.DateCommande = c.DateCommande;
                upCde.Observation = c.Observation;
                upCde.ClientId = c.ClientId;
                upCde.StatutId = c.StatutId;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un commande en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="commandeID">Identifiant du commande à supprimer</param>
        public void Supprimer(int commandeID)
        {
            Commande delCde = _contexte.Commandes.Where(cde => cde.Id == commandeID).FirstOrDefault();
            if (delCde != null)
            {
                _contexte.Commandes.Remove(delCde);
            }
            _contexte.SaveChanges();
        }
    }
}
