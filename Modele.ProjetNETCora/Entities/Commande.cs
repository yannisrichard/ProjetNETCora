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
    public class Commande
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset DateCommande { get; set; }

        [StringLength(50)]
        [Required]
        public string Observation { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int StatutId { get; set; }
        public Statut Statut { get; set; }

        public ICollection<CommandeProduit> CommandesProduits { get; set; }

    }


}
