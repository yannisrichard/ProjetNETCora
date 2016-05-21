using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Modele.ProjetNETCora;
using Modele.ProjetNETCora.Entities;

namespace Modele.Console.ProjetNETCora
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestEntityFramework();
            //clearBDD();
        }

        // permet de tester EF (EntityFramework)
        public static void TestEntityFramework()
        {
            // test du contexte avec api fluent
            Contexte contexte = new Contexte();

           

            //Test ajout commandeproduit table associative
            List<CommandeProduit> commandesproduits = new List<CommandeProduit>();
            commandesproduits.Add(new CommandeProduit { Quantite = 5 });
            List<Produit> produits = new List<Produit>();
            produits.Add(new Produit { Code = 1, Libelle = "Produit", Description = null, Actif = false, Stock = 01, Prix = 10.00, CommandesProduits = commandesproduits });
            contexte.Categories.Add(new Categorie { Libelle = "1ere Commande", Actif = true, Produits = produits });

            // ajout d'un nouveau client avec un compte
            List<Commande> commandes = new List<Commande>();
            commandes.Add(new Commande { DateCommande = DateTime.Now, Observation = "Enchanteur", CommandesProduits = commandesproduits });
            contexte.Clients.Add(new Client { Nom = "Lasticot", Prenom = "Coco", Actif = true, Commandes = commandes });
            contexte.Statuts.Add(new Statut { Libelle = "1ere Commande", Commandes = commandes });
            contexte.SaveChanges();


            // lecture des clients
            List<Client> mesAutresClients = contexte.Clients.Include(c => c.Commandes).ToList();
            System.Console.WriteLine(" Liste de mes clients : ");
            foreach (Client c in mesAutresClients)
            {
                System.Console.WriteLine("Client n°{0} : {1}", c.Id, c.Nom);
                foreach (Commande cc in c.Commandes)
                {
                    System.Console.WriteLine("|__ Commande n°{0}, Observation : ", cc.Observation);
                }
            }

            List<CommandeProduit> mescp = contexte.CommandesProduits.ToList();
            System.Console.WriteLine(" Liste commandes produits : ");
            foreach (CommandeProduit cp in mescp)
            {
                System.Console.WriteLine("Commande Produit n°{0} : {1} - qte = {2}", cp.CommandeId, cp.ProduitId, cp.Quantite);
            }

            System.Console.WriteLine("...Fin...");
        }

        // permet de clear bdd
        public static void clearBDD()
        {
            // test du contexte avec api fluent
            Contexte contexte = new Contexte();

            // suppresion des clients
            List<Client> clients = contexte.Clients.ToList();
            foreach (Client c in clients)
            {
                contexte.Clients.Remove(c);
                contexte.SaveChanges();
            }
            System.Console.WriteLine("Clients supprimés");

            // suppresion des status
            List<Statut> statuts = contexte.Statuts.ToList();
            foreach (Statut s in statuts)
            {
                contexte.Statuts.Remove(s);
                contexte.SaveChanges();
            }
            System.Console.WriteLine("Statuts supprimés");

            // suppresion des commandes
            List<Commande> commandes = contexte.Commandes.ToList();
            foreach (Commande c in commandes)
            {
                contexte.Commandes.Remove(c);
                contexte.SaveChanges();
            }
            System.Console.WriteLine("Commandes supprimées");


            System.Console.WriteLine("...Fin suppression...");
        }
    }
}

