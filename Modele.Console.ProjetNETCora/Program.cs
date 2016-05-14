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

            // ajout d'un nouveau client avec un compte
            List<Commande> commandes = new List<Commande>();
            commandes.Add(new Commande { DateCommande = DateTime.Now, Observation = "Enchanteur" });
            contexte.Clients.Add(new Client { Nom = "Lasticot", Prenom = "Coco", Actif = true, Commandes = commandes });
            contexte.Statuts.Add(new Statut { Libelle = "1ere Commande", Commandes = commandes });
            contexte.SaveChanges();

            // lecture des clients
            List<Client> mesAutresClients = contexte.Clients.Include(c => c.Commandes).ToList();
            System.Console.WriteLine("Liste de mes clients : ");
            foreach (Client c in mesAutresClients)
            {
                System.Console.WriteLine("Client n°{0} : {1}", c.Id, c.Nom);
                foreach (Commande cc in c.Commandes)
                {
                    System.Console.WriteLine("|__ Commande n°{0}, Observation : ", cc.Observation);
                }
            }
            System.Console.WriteLine("...Fin...");
        }

        // permet de tester EF (EntityFramework)
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


            System.Console.WriteLine("...Fin. suppression...");
        }
    }
}

