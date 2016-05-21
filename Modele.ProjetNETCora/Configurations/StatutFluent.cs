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
    public class StatutFluent : EntityTypeConfiguration<Statut>
    {
        public StatutFluent()
        {
            ToTable("APP_STATUT");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("STA_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Libelle).HasColumnName("STA_LIBELLE").IsRequired().HasMaxLength(50);

            HasMany(c => c.Commandes).WithRequired(cc => cc.Statut).HasForeignKey(cc => cc.StatutId);

        }
    }
}
