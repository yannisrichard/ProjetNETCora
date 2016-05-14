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
       

    }

    public class CommandeProduitFluent : EntityTypeConfiguration<CommandeProduit>
    {
        public CommandeProduitFluent()
        {
            ToTable("APP_COMMANDEPRODUIT");
           

        }
    }
}
