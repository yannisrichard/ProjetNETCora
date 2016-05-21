using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ProjetNETCora.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Modele.ProjetNETCora.Configurations
{
    public class CategorieFluent : EntityTypeConfiguration<Categorie>
    {
        public CategorieFluent()
        {
            ToTable("APP_CATEGORIE");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CAT_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Libelle).HasColumnName("CAT_LIBELLE").IsRequired().HasMaxLength(50);
            Property(c => c.Actif).HasColumnName("CAT_ACTIF").IsRequired();

            HasMany(c => c.Produits).WithRequired(cc => cc.Categorie).HasForeignKey(cc => cc.CategorieId);

        }
    }
}
