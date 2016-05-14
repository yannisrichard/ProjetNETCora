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
    public class LogProduit
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Message { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }


        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

    }

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
