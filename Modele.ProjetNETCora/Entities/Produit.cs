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
        public ICollection<CommandeProduit> CommandesProduits { get; set; }


    }


}
