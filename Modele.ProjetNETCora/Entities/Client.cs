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


}
