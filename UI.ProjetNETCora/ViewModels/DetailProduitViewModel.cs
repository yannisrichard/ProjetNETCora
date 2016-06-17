using BusinessLayer.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using UI.ProjetNETCora.Mock;
using UI.ProjetNETCora.ViewModels.Common;

namespace UI.ProjetNETCora.ViewModels
{
    /// <summary>
    /// ViewModel représentant un Produit (avec son détail)
    /// Hérite de BaseViewModel
    /// </summary>
    public class DetailProduitViewModel : BaseViewModel
    {
        #region Variables

        private int _id;
        private int _code;
        private string _libelle;
        private string _description;
        private bool _actif;
        private int _stock;
        private double _prix;
        private int _categorieID;

        private RelayCommand _addOperation;
        private RelayCommand _modifierStock;

        private Views.Operation operationWindow;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="p">Produit à transformer en DetailProduitViewModel</param>
        /// </summary>
        public DetailProduitViewModel(Produit p)
        {
            _id = p.Id;
            _code = p.Code;
            _libelle = p.Libelle;
            _description = p.Description;
            _actif = p.Actif;
            _stock = p.Stock;
            _prix = p.Prix;
            _categorieID = p.CategorieId;
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Code du produit
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Code du produit
        /// </summary>
        public int Code 
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// Libelle du produit
        /// </summary>
        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }

        /// <summary>
        /// Description du produit
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Actif du produit
        /// </summary>
        public bool Actif
        {
            get { return _actif; }
            set { _actif = value; }
        }


        /// <summary>
        /// Stock du produit
        /// </summary>
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        /// <summary>
        /// Prix du produit
        /// </summary>
        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        /// <summary>
        /// CategorieID du produit
        /// </summary>
        public int CategorieID
        {
            get { return _categorieID; }
            set { _categorieID = value; }
        }


        #endregion

        #region Commandes

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une opération
        /// </summary>
        public ICommand AddOperation
        {
            get
            {
                if (_addOperation == null)
                    _addOperation = new RelayCommand(() => this.ShowWindowOperation());
                return _addOperation;
            }
        }

        /// <summary>
        /// Permet l'ouverture de la fenêtre
        /// </summary>
        private void ShowWindowOperation()
        {
            operationWindow = new Views.Operation();
            operationWindow.DataContext = this;
            operationWindow.ShowDialog();
        }

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une opération
        /// </summary>
        public ICommand ModifierStock
        {
            get
            {
                if (_modifierStock == null)
                    _modifierStock = new RelayCommand(() => this.ModifierStockOperation());
                return _modifierStock;
            }
        }

        /// <summary>
        /// Modifier stock operation
        /// </summary>
        private void ModifierStockOperation()
        {
            //A Terminer Sotckoperation
            Produit p = Manager.Instance.GetByIdProduit(Id);
            p.Code = Code;
            p.Stock = Stock;
            Manager.Instance.ModifierProduit(p);
            operationWindow.Close();
        }

        #endregion
    }
}
