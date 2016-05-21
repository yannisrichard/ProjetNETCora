using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ProjetNETCora.Configurations
{
    public class CommandeProduitFluent : EntityTypeConfiguration<CommandeProduit>
    {
        public CommandeProduitFluent()
        {
            ToTable("APP_COMMANDEPRODUIT");
            HasKey(c => new { c.ProduitId, c.CommandeId } );

            Property(c => c.ProduitId).HasColumnName("CPD_PRODUITID").IsRequired();
            Property(c => c.CommandeId).HasColumnName("CPD_COMMANDEID").IsRequired();
            Property(c => c.Quantite).HasColumnName("CPD_QUANTITE").IsRequired();

            HasRequired(cc => cc.Produit).WithMany(c => c.CommandesProduits).HasForeignKey(c => c.ProduitId);
            HasRequired(cc => cc.Commande).WithMany(c => c.CommandesProduits).HasForeignKey(c => c.CommandeId);

        }
    }
}
