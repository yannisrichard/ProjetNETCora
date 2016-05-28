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
    /// COMMAND pour ajouter / modifier et supprimer un client
    /// </summary>
    public class ClientCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public ClientCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter le client en base à partir du contexte
        /// </summary>
        /// <param name="p">Client à ajouter</param>
        /// <returns>Identifiant du client ajouté</returns>
        public int Ajouter(Client c)
        {
            _contexte.Clients.Add(c);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un client déjà présent en base à partir du cotnexte
        /// </summary>
        /// <param name="c">Client à modifier</param>
        public void Modifier(Client c)
        {
            Client upCli = _contexte.Clients.Where(cli => cli.Id == c.Id).FirstOrDefault();
            if (upCli != null)
            {
                upCli.Nom = c.Nom;
                upCli.Prenom = c.Prenom;
                upCli.Actif = c.Actif;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un client en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="clientID">Identifiant du client à supprimer</param>
        public void Supprimer(int clientID)
        {
            Client delCli = _contexte.Clients.Where(cli => cli.Id == clientID).FirstOrDefault();
            if (delCli != null)
            {
                _contexte.Clients.Remove(delCli);
            }
            _contexte.SaveChanges();
        }
    }
}
