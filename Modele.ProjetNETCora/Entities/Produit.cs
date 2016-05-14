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
    public class Produit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool Actif { get; set; }

        public int Stock { get; set; }

        [Required]
        public Double Prix { get; set; }

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public ICollection<LogProduit> LogProduits { get; set; }


    }

    public class ProduitFluent : EntityTypeConfiguration<Produit>
    {
        public ProduitFluent()
        {
            ToTable("APP_PRODUIT");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("PRD_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Libelle).HasColumnName("PRD_LIBELLE").IsRequired().HasMaxLength(50);
            Property(c => c.Description).HasColumnName("PRD_DESCRIPTION").IsOptional().HasMaxLength(50);
            Property(c => c.Actif).HasColumnName("PRD_ACTIF").IsOptional();
            Property(c => c.Stock).HasColumnName("PRD_STOCK").IsOptional();
            Property(c => c.Prix).HasColumnName("PRD_PRIX").IsRequired();

            HasRequired(cc => cc.Categorie).WithMany(c => c.Produits).HasForeignKey(c => c.CategorieId);

            HasMany(c => c.LogProduits).WithRequired(cc => cc.Produit).HasForeignKey(cc => cc.ProduitId);

        }
    }
}
