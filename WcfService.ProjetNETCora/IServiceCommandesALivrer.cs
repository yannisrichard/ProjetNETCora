using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService.ProjetNETCora
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceCommandesALivrer" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceCommandesALivrer
    {
        // on retourne un simple "message" sans utiliser de datacontract
        // on retourne un datacontract défini
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "commandes")]
        List<Commande> GetCommandes();
    }
}
