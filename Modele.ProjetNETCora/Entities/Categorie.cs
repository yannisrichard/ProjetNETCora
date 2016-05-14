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
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Libelle { get; set; }

        [StringLength(50)]
        [Required]
        public string Actif { get; set; }

        public ICollection<Produit> Produits { get; set; }


    }

    public class CategorieFluent : EntityTypeConfiguration<Categorie>
    {
        public CategorieFluent()
        {
            ToTable("APP_CATEGORIE");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CAT_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Libelle).HasColumnName("CAT_LIBELLE").IsRequired().HasMaxLength(50);
            Property(c => c.Actif).HasColumnName("CAT_ACTIF").IsRequired().HasMaxLength(50);

            HasMany(c => c.Produits).WithRequired(cc => cc.Categorie).HasForeignKey(cc => cc.CategorieId);

        }
    }
}
