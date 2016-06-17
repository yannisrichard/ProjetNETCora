using BusinessLayer.ProjetNETCora.Commands;
using BusinessLayer.ProjetNETCora.Queries;
using Modele.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProjetNETCora
{
    /// <summary>
    /// Manager de la BusinessLayer
    /// Cette classe est un singleton est instancie un contexte EF dans son constructeur
    /// </summary>
    public class Manager
    {
        private readonly Contexte contexte;
        private static Manager _businessManager = null;

        /// <summary>
        /// Constructeur, initialisation du contexte EF
        /// </summary>
        private Manager()
        {
            contexte = new Contexte();
        }

        /// <summary>
        /// Récupérer l'instance du pattern Singleton
        /// </summary>
        public static Manager Instance
        {
            get
            {
                if (_businessManager == null)
                    _businessManager = new Manager();
                return _businessManager;
            }
        }

        #region Categorie

        /// <summary>
        /// Récupérer une liste de catégories en base
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public List<Categorie> GetAllCategorie()
        {
            CategorieQuery cq = new CategorieQuery(contexte);
            return cq.GetAll().ToList();
        }

        /// <summary>
        /// Ajouter un categorie en base
        /// </summary>
        /// <param name="c">Categorie à ajouter</param>
        /// <returns>identifiant du nouveau categorie</returns>
        public int AjouterCategorie(Categorie c)
        {
            // TODO : ajouter des contrôles sur le categorie (exemple : vérification de champ, etc.)
            CategorieCommand cc = new CategorieCommand(contexte);
            return cc.Ajouter(c);
        }

        /// <summary>
        /// Modifier un categorie en base
        /// </summary>
        /// <param name="c">Categorie à modifier</param>
        public void ModifierCategorie(Categorie c)
        {
            // TODO : ajouter des contrôles sur le categorie (exemple : vérification de champ, etc.)
            CategorieCommand cc = new CategorieCommand(contexte);
            cc.Modifier(c);
        }

        /// <summary>
        /// Supprimer une categorie en base
        /// </summary>
        /// <param name="categorieID">Identifiant du categorie à supprimer</param>
        public void SupprimerCategorie(int categorieID)
        {
            CategorieCommand cc = new CategorieCommand(contexte);
            cc.Supprimer(categorieID);
        }

        #endregion

        #region Client

        /// <summary>
        /// Récupérer une liste de clients en base
        /// </summary>
        /// <returns>Liste de Client</returns>
        public List<Client> GetAllClient()
        {
            ClientQuery cq = new ClientQuery(contexte);
            return cq.GetAll().ToList();
        }

        /// <summary>
        /// Ajouter un client en base
        /// </summary>
        /// <param name="c">Client à ajouter</param>
        /// <returns>identifiant du nouveau client</returns>
        public int AjouterClient(Client c)
        {
            // TODO : ajouter des contrôles sur le client (exemple : vérification de champ, etc.)
            ClientCommand cc = new ClientCommand(contexte);
            return cc.Ajouter(c);
        }

        /// <summary>
        /// Modifier un client en base
        /// </summary>
        /// <param name="c">Client à modifier</param>
        public void ModifierClient(Client c)
        {
            // TODO : ajouter des contrôles sur le client (exemple : vérification de champ, etc.)
            ClientCommand cc = new ClientCommand(contexte);
            cc.Modifier(c);
        }

        /// <summary>
        /// Supprimer une client en base
        /// </summary>
        /// <param name="clientID">Identifiant du client à supprimer</param>
        public void SupprimerClient(int clientID)
        {
            ClientCommand cc = new ClientCommand(contexte);
            cc.Supprimer(clientID);
        }

        #endregion

        #region Commande

        /// <summary>
        /// Récupérer une liste de commandes en base
        /// </summary>
        /// <returns>Liste de Commande</returns>
        public List<Commande> GetAllCommande()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.GetAll().ToList();
        }

        /// <summary>
        /// Ajouter un commande en base
        /// </summary>
        /// <param name="c">Commande à ajouter</param>
        /// <returns>identifiant du nouveau commande</returns>
        public int AjouterCommande(Commande c)
        {
            // TODO : ajouter des contrôles sur le commande (exemple : vérification de champ, etc.)
            CommandeCommand cc = new CommandeCommand(contexte);
            return cc.Ajouter(c);
        }

        /// <summary>
        /// Modifier un commande en base
        /// </summary>
        /// <param name="c">Commande à modifier</param>
        public void ModifierCommande(Commande c)
        {
            // TODO : ajouter des contrôles sur le commande (exemple : vérification de champ, etc.)
            CommandeCommand cc = new CommandeCommand(contexte);
            cc.Modifier(c);
        }

        /// <summary>
        /// Supprimer une commande en base
        /// </summary>
        /// <param name="commandeID">Identifiant du commande à supprimer</param>
        public void SupprimerCommande(int commandeID)
        {
            CommandeCommand cc = new CommandeCommand(contexte);
            cc.Supprimer(commandeID);
        }

        #endregion

        #region CommandeProduit

        /// <summary>
        /// Récupérer une liste de commandesProduits en base
        /// </summary>
        /// <returns>Liste de CommandeProduit</returns>
        public List<CommandeProduit> GetAllCommandeProduit()
        {
            CommandeProduitQuery cpq = new CommandeProduitQuery(contexte);
            return cpq.GetAll().ToList();
        }

        /// <summary>
        /// Ajouter une commandeProduit en base
        /// </summary>
        /// <param name="cp">CommandeProduit à ajouter</param>
        /// <returns>identifiant du nouveau commandeProduit</returns>
        public int AjouterCommandeProduit(CommandeProduit cp)
        {
            // TODO : ajouter des contrôles sur le commandeProduit (exemple : vérification de champ, etc.)
            CommandeProduitCommand cpc = new CommandeProduitCommand(contexte);
            return cpc.Ajouter(cp);
        }

        /// <summary>
        /// Modifier une commandeProduit en base
        /// </summary>
        /// <param name="cp">CommandeProduit à modifier</param>
        public void ModifierCommandeProduit(CommandeProduit cp)
        {
            // TODO : ajouter des contrôles sur le commandeProduit (exemple : vérification de champ, etc.)
            CommandeProduitCommand cpc = new CommandeProduitCommand(contexte);
            cpc.Modifier(cp);
        }

        /// <summary>
        /// Supprimer une commandeProduit en base
        /// </summary>
        /// <param name="produitID">Identifiant du commandeProduit à supprimer</param>
        /// <param name="commandeID">Identifiant du commandeProduit à supprimer</param>
        public void SupprimerCommandeProduit(int produitID, int commandeID)
        {
            CommandeProduitCommand cpc = new CommandeProduitCommand(contexte);
            cpc.Supprimer(produitID, commandeID);
        }

        #endregion

        #region LogProduit

        /// <summary>
        /// Récupérer une liste de logproduit en base
        /// </summary>
        /// <returns>Liste de LogProduit</returns>
        public List<LogProduit> GetAllLogProduit()
        {
            LogProduitQuery lpq = new LogProduitQuery(contexte);
            return lpq.GetAll().ToList();
        }

        /// <summary>
        /// Ajouter un logproduit en base
        /// </summary>
        /// <param name="p">LogProduit à ajouter</param>
        /// <returns>identifiant du nouveau logproduit</returns>
        public int AjouterLogProduit(LogProduit lp)
        {
            // TODO : ajouter des contrôles sur le logproduit (exemple : vérification de champ, etc.)
            LogProduitCommand lpc = new LogProduitCommand(contexte);
            return lpc.Ajouter(lp);
        }

        /// <summary>
        /// Modifier un logproduit en base
        /// </summary>
        /// <param name="p">LogProduit à modifier</param>
        public void ModifierLogProduit(LogProduit lp)
        {
            // TODO : ajouter des contrôles sur le logproduit (exemple : vérification de champ, etc.)
            LogProduitCommand lpc = new LogProduitCommand(contexte);
            lpc.Modifier(lp);
        }

        /// <summary>
        /// Supprimer une logproduit en base
        /// </summary>
        /// <param name="logproduitID">Identifiant du logproduit à supprimer</param>
        public void SupprimerLogProduit(int logproduitID)
        {
            LogProduitCommand lpc = new LogProduitCommand(contexte);
            lpc.Supprimer(logproduitID);
        }

        #endregion

        #region Produit

        /// <summary>
        /// Récupérer une liste de produit en base
        /// </summary>
        /// <returns>Liste de Produit</returns>
        public List<Produit> GetAllProduit()
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer un produit par son ID
        /// </summary>
        /// <param name="id">Identifiant du produit à récupérer</param>
        /// <returns>IQueryable de Produit</returns>
        public Produit GetByIdProduit(int id)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetByID(id).FirstOrDefault();
        }

        /// <summary>
        /// Ajouter un produit en base
        /// </summary>
        /// <param name="p">Produit à ajouter</param>
        /// <returns>identifiant du nouveau produit</returns>
        public int AjouterProduit(Produit p)
        {
            // TODO : ajouter des contrôles sur le produit (exemple : vérification de champ, etc.)
            ProduitCommand pc = new ProduitCommand(contexte);
            return pc.Ajouter(p);
        }

        /// <summary>
        /// Modifier un produit en base
        /// </summary>
        /// <param name="p">Produit à modifier</param>
        public void ModifierProduit(Produit p)
        {
            // TODO : ajouter des contrôles sur le produit (exemple : vérification de champ, etc.)
            ProduitCommand pc = new ProduitCommand(contexte);
            pc.Modifier(p);
        }

        /// <summary>
        /// Supprimer une produit en base
        /// </summary>
        /// <param name="produitID">Identifiant du produit à supprimer</param>
        public void SupprimerProduit(int produitID)
        {
            ProduitCommand pc = new ProduitCommand(contexte);
            pc.Supprimer(produitID);
        }

        #endregion

        #region Statut

        /// <summary>
        /// Récupérer une liste de statuts en base
        /// </summary>
        /// <returns>Liste de Statut</returns>
        public List<Statut> GetAllStatut()
        {
            StatutQuery pq = new StatutQuery(contexte);
            return pq.GetAll().ToList();
        }

        /// <summary>
        /// Ajouter un statut en base
        /// </summary>
        /// <param name="s">Statut à ajouter</param>
        /// <returns>identifiant du nouveau statut</returns>
        public int AjouterStatut(Statut s)
        {
            // TODO : ajouter des contrôles sur le statut (exemple : vérification de champ, etc.)
            StatutCommand sc = new StatutCommand(contexte);
            return sc.Ajouter(s);
        }

        /// <summary>
        /// Modifier un statut en base
        /// </summary>
        /// <param name="p">Statut à modifier</param>
        public void ModifierStatut(Statut s)
        {
            // TODO : ajouter des contrôles sur le statut (exemple : vérification de champ, etc.)
            StatutCommand sc = new StatutCommand(contexte);
            sc.Modifier(s);
        }

        /// <summary>
        /// Supprimer une statut en base
        /// </summary>
        /// <param name="statutID">Identifiant du statut à supprimer</param>
        public void SupprimerStatut(int statutID)
        {
            StatutCommand sc = new StatutCommand(contexte);
            sc.Supprimer(statutID);
        }

        #endregion





    }
}
