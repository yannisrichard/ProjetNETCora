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
    /// COMMAND pour ajouter / modifier et supprimer un commandeProduit
    /// </summary>
    public class CommandeProduitCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CommandeProduitCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter le commandeProduit en base à partir du contexte
        /// </summary>
        /// <param name="p">CommandeProduit à ajouter</param>
        /// <returns>Identifiant du commandeProduit ajouté</returns>
        public int Ajouter(CommandeProduit cp)
        {
            _contexte.CommandesProduits.Add(cp);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un commandeProduit déjà présent en base à partir du cotnexte
        /// </summary>
        /// <param name="p">CommandeProduit à modifier</param>
        public void Modifier(CommandeProduit cp)
        {
            CommandeProduit upCdePrd = _contexte.CommandesProduits.Where(cdeprd => cdeprd.ProduitId == cp.ProduitId && cdeprd.CommandeId == cp.CommandeId).FirstOrDefault();
            if (upCdePrd != null)
            {
                upCdePrd.Quantite = cp.Quantite;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un commandeProduit en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="commandeProduitID">Identifiant du commandeProduit à supprimer</param>
        public void Supprimer(int produitID, int commandeID)
        {
            CommandeProduit delCdePrd = _contexte.CommandesProduits.Where(cdeprd => cdeprd.ProduitId == produitID && cdeprd.CommandeId == commandeID).FirstOrDefault();
            if (delCdePrd != null)
            {
                _contexte.CommandesProduits.Remove(delCdePrd);
            }
            _contexte.SaveChanges();
        }
    }
}
