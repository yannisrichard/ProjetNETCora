using BusinessLayer.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.ProjetNETCora
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceCommandesALivrer" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceCommandesALivrer.svc ou ServiceCommandesALivrer.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceCommandesALivrer : IServiceCommandesALivrer
    {
        public List<Commande> GetCommandes()
        {
            List<Commande> lstCommandes = Manager.Instance.GetAllCommande();

            return lstCommandes;
        }
    }
}
