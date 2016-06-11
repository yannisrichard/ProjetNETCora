using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ProjetNETCora.Mock
{
    /// <summary>
    /// Business MOCK
    /// </summary>
    public class BusinessManagerMock
    {
        private static BusinessManagerMock _businessManager = null;

        /// <summary>
        /// Constructeur
        /// </summary>
        private BusinessManagerMock()
        {
        }

        /// <summary>
        /// Récupérer l'instance du pattern Singleton
        /// </summary>
        public static BusinessManagerMock Instance
        {
            get
            {
                if (_businessManager == null)
                    _businessManager = new BusinessManagerMock();
                return _businessManager;
            }
        }

        /// <summary>
        /// Méthode pour simuler un appel au contexte pour renvoyer une liste de produits
        /// </summary>
        /// <returns></returns>
        public List<Produit> GetAllProduit()
        {
            List<Produit> produits = new List<Produit>();
            produits.Add(new Produit { Code = "2ER45", Nom = "Huile d'olive végétale" });
            produits.Add(new Produit { Code = "3ZZ21", Nom = "Magrets de canard" });
            produits.Add(new Produit { Code = "45WXB", Nom = "Terrine de truite" });
            return produits;
        }
    }
}
