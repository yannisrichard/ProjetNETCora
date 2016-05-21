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
    public class ClientFluent : EntityTypeConfiguration<Client>
    {
        public ClientFluent()
        {
            ToTable("APP_CLIENT");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CLI_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nom).HasColumnName("CLI_NOM").IsRequired().HasMaxLength(50);
            Property(c => c.Prenom).HasColumnName("CLI_PRENOM").IsOptional().HasMaxLength(50);
            Property(c => c.Actif).HasColumnName("CLI_ACTIF").IsOptional();

            HasMany(c => c.Commandes).WithRequired(cc => cc.Client).HasForeignKey(cc => cc.ClientId);

        }
    }
}
