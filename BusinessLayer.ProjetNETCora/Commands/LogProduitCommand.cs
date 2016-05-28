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
    /// COMMAND pour ajouter / modifier et supprimer un logproduit
    /// </summary>
    public class LogProduitCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public LogProduitCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter le logproduit en base à partir du contexte
        /// </summary>
        /// <param name="p">LogProduit à ajouter</param>
        /// <returns>Identifiant du logproduit ajouté</returns>
        public int Ajouter(LogProduit lp)
        {
            _contexte.LogProduits.Add(lp);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un logproduit déjà présent en base à partir du cotnexte
        /// </summary>
        /// <param name="p">LogProduit à modifier</param>
        public void Modifier(LogProduit lp)
        {
            LogProduit upLogPrd = _contexte.LogProduits.Where(logPrd => logPrd.Id == lp.Id).FirstOrDefault();
            if (upLogPrd != null)
            {
                upLogPrd.Message = lp.Message;
                upLogPrd.Date = lp.Date;
                upLogPrd.ProduitId = lp.ProduitId;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un logproduit en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="logproduitID">Identifiant du logproduit à supprimer</param>
        public void Supprimer(int logproduitID)
        {
            LogProduit delLogPrd = _contexte.LogProduits.Where(logPrd => logPrd.Id == logproduitID).FirstOrDefault();
            if (delLogPrd != null)
            {
                _contexte.LogProduits.Remove(delLogPrd);
            }
            _contexte.SaveChanges();
        }
    }
}
