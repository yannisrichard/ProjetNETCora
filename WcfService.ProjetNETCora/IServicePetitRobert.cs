using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService.ProjetNETCora
{
    [ServiceContract]
    public interface IServicePetitRobert
    {
        // on retourne un simple "message" sans utiliser de datacontract
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "nombreLettre?mot={mot}")]
        string GetNombreLettreMot(string mot);

        // on retourne un datacontract défini
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "information?mot={mot}")]
        MotDuDictionnaire GetInformationMot(string mot);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class MotDuDictionnaire
    {
        public MotDuDictionnaire(string mot)
        {
            Mot = mot;
            NbLettre = mot.Count();
            PremiereLettre = mot.Substring(0, 1).ToString();
        }

        [DataMember]
        public string Mot { get; set; }

        [DataMember]
        public string Definition { get; set; }

        [DataMember]
        public int NbLettre { get; set; }

        [DataMember]
        public string PremiereLettre { get; set; }
    }
}
