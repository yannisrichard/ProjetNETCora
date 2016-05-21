using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ProjetNETCora.Configurations
{

    public class LogProduitFluent : EntityTypeConfiguration<LogProduit>
    {
        public LogProduitFluent()
        {
            ToTable("APP_LOGPRODUIT");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("LOG_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Message).HasColumnName("LOG_MESSAGE").IsRequired().HasMaxLength(50);
            Property(c => c.Date).HasColumnName("LOG_DATE").IsRequired();

            HasRequired(cc => cc.Produit).WithMany(c => c.LogProduits).HasForeignKey(c => c.ProduitId);


        }
    }
}
