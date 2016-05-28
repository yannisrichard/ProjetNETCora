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
    /// COMMAND pour ajouter / modifier et supprimer un categorie
    /// </summary>
    public class CategorieCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CategorieCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter le categorie en base à partir du contexte
        /// </summary>
        /// <param name="c">Categorie à ajouter</param>
        /// <returns>Identifiant du categorie ajouté</returns>
        public int Ajouter(Categorie c)
        {
            _contexte.Categories.Add(c);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un categorie déjà présent en base à partir du cotnexte
        /// </summary>
        /// <param name="c">Categorie à modifier</param>
        public void Modifier(Categorie c)
        {
            Categorie upCat = _contexte.Categories.Where(cat => cat.Id == c.Id).FirstOrDefault();
            if (upCat != null)
            {
                upCat.Libelle = c.Libelle;
                upCat.Actif = c.Actif;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un categorie en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="categorieID">Identifiant du categorie à supprimer</param>
        public void Supprimer(int categorieID)
        {
            Categorie delCat = _contexte.Categories.Where(cat => cat.Id == categorieID).FirstOrDefault();
            if (delCat != null)
            {
                _contexte.Categories.Remove(delCat);
            }
            _contexte.SaveChanges();
        }
    }
}
