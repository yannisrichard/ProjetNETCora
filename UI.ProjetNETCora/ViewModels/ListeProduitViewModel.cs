using BusinessLayer.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ProjetNETCora.ViewModels.Common;

namespace UI.ProjetNETCora.ViewModels
{
    /// <summary>
    /// ViewModel permettant de gérer une liste de DetailProduitViewModel
    /// Hérite de BaseViewModel
    /// </summary>
    public class ListeProduitViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<DetailProduitViewModel> _produits = null;
        private DetailProduitViewModel _selectedProduit;
        private RelayCommand _updateProduits;
        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListeProduitViewModel()
        {
            _produits = new ObservableCollection<DetailProduitViewModel>();
            foreach (Produit p in Manager.Instance.GetAllProduit())
            {
                _produits.Add(new DetailProduitViewModel(p));
            }

            if (_produits != null && _produits.Count > 0)
                _selectedProduit = _produits.ElementAt(0);
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit une collection de DetailProduitViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailProduitViewModel> Produits
        {
            get { return _produits; }
            set
            {
                _produits = value;
                OnPropertyChanged("Produits");
            }
        }

        /// <summary>
        /// Obtient ou défini le produit en cours de sélection dans la liste de DetailProduitViewModel
        /// </summary>
        public DetailProduitViewModel SelectedProduit
        {
            get { return _selectedProduit; }
            set
            {
                _selectedProduit = value;
                OnPropertyChanged("SelectedProduit");
            }
        }


        #endregion

        #region Commandes

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une opération
        /// </summary>
        public ICommand UpdateProduits
        {
            get
            {
                if (_updateProduits == null)
                    _updateProduits = new RelayCommand(() => this.MettreAJourLaListeDeProduits());
                return _updateProduits;
            }
        }

        /// <summary>
        /// Modifier stock operation
        /// </summary>
        private void MettreAJourLaListeDeProduits()
        {
            Produits.Clear();
            foreach (Produit p in Manager.Instance.GetAllProduit())
            {
                Produits.Add(new DetailProduitViewModel(p));
            }

            if (Produits != null && Produits.Count > 0)
                SelectedProduit = Produits.ElementAt(0);
        }

        #endregion
    }
}
