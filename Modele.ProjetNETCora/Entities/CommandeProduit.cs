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
    public class CommandeProduit
    {
        [Key, Column(Order=0)]
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

        [Key, Column(Order = 1)]
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        [Required]
        public int Quantite { get; set; }



    }
    
}
