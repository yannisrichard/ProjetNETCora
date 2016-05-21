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

        [Required]
        public bool Actif { get; set; }

        public ICollection<Produit> Produits { get; set; }

    }


}
