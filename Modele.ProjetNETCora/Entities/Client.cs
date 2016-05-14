using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ProjetNETCora.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        public bool Actif { get; set; }

        public ICollection<Commande> Commandes { get; set; }


    }

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
