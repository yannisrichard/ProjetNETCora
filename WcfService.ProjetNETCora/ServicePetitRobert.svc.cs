using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService.ProjetNETCora
{
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServicePetitRobert : IServicePetitRobert
    {
        public string GetNombreLettreMot(string mot)
        {
            return string.Format("Le mot {0} contient {1} lettre(s)", mot, mot.Count());
        }

        public MotDuDictionnaire GetInformationMot(string mot)
        {
            if (String.IsNullOrWhiteSpace(mot))
            {
                throw new ArgumentNullException("mot");
            }

            MotDuDictionnaire motDuDictionnaire = new MotDuDictionnaire(mot);
            motDuDictionnaire.Definition = "Definition à aller chercher en base de ce mot";

            return motDuDictionnaire;
        }
    }
}
