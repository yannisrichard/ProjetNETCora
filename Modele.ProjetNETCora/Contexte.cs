using Modele.ProjetNETCora.Configurations;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ProjetNETCora
{
    public class Contexte : DbContext
    {
        public Contexte() : base("name=ProjetNETCoraConnexionString") 
        {
            //Drop puis create
            //Database.SetInitializer<Contexte>(new DropCreateDatabaseAlways<Contexte>());
            //Pas de drop
            Database.SetInitializer<Contexte>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            //modelBuilder.Configurations.Add(new ClientFluent());
            //modelBuilder.Configurations.Add(new StatutFluent());
            //modelBuilder.Configurations.Add(new CommandeFluent());
            //modelBuilder.Configurations.Add(new CategorieFluent());
            //modelBuilder.Configurations.Add(new ProduitFluent());
            //modelBuilder.Configurations.Add(new LogProduitFluent());
            //modelBuilder.Configurations.Add(new CommandeProduitFluent());

            //TODO : Astuce Prend toutes les assemblys fluent
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Statut> Statuts { get; set; }

        public DbSet<Commande> Commandes { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Produit> Produits { get; set; }

        public DbSet<LogProduit> LogProduits { get; set; }

        public DbSet<CommandeProduit> CommandesProduits { get; set; }



    }
}
