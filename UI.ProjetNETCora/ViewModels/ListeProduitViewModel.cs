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
        private String _filtreProduits;
        private int _code;
        private String _libelle;
        private String _description;
        private bool _actif;
        private int _stock;
        private Double _prix;
        private int _categorie;

        private RelayCommand _updateProduits;
        private RelayCommand _deleteProduits;
        private RelayCommand _openWindowAddProduit;
        private RelayCommand _btnAddProduit;
        private RelayCommand _btnRechercheProduit;
        
        private Views.AjouterProduit addProduitWindow;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListeProduitViewModel()
        {
            Actif = true;
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
        /// <summary>
        /// Databinding FiltreProduits
        /// </summary>
        public String FiltreProduits
        {
            get { return _filtreProduits; }
            set
            {
                _filtreProduits = value;
                OnPropertyChanged("FiltreProduits");
            }
        }

        /// <summary>
        /// Databinding Code
        /// </summary>
        public int Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }
        /// <summary>
        /// Databinding Libelle
        /// </summary>
        public String Libelle
        {
            get { return _libelle; }
            set
            {
                _libelle = value;
                OnPropertyChanged("Libelle");
            }
        }
        /// <summary>
        /// Databinding Description
        /// </summary>
        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        /// <summary>
        /// Databinding Actif
        /// </summary>
        public bool Actif
        {
            get { return _actif; }
            set
            {
                _actif = value;
                OnPropertyChanged("Actif");
            }
        }
        /// <summary>
        /// Databinding Stock
        /// </summary>
        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                OnPropertyChanged("Stock");
            }
        }
        /// <summary>
        /// Databinding Prix
        /// </summary>
        public Double Prix
        {
            get { return _prix; }
            set
            {
                _prix = value;
                OnPropertyChanged("Prix");
            }
        }
        /// <summary>
        /// Databinding Categorie
        /// </summary>
        public int Categorie
        {
            get { return _categorie; }
            set
            {
                _categorie = value;
                OnPropertyChanged("Categorie");
            }
        }
        #endregion

        #region Commandes

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une opération
        /// </summary>
        public ICommand OpenWindowAddProduit
        {
            get
            {
                if (_openWindowAddProduit == null)
                    _openWindowAddProduit = new RelayCommand(() => this.ShowAddProduits());
                return _openWindowAddProduit;
            }
        }

        /// <summary>
        /// Permet l'ouverture de la fenêtre
        /// </summary>
        private void ShowAddProduits()
        {
            addProduitWindow = new Views.AjouterProduit();
            addProduitWindow.DataContext = this;
            addProduitWindow.ShowDialog();
        }

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une opération
        /// </summary>
        public ICommand BtnAddProduit
        {
            get
            {
                if (_btnAddProduit == null)
                    _btnAddProduit = new RelayCommand(() => this.AddProduit());
                return _btnAddProduit;
            }
        }

        /// <summary>
        /// Modifier stock operation
        /// </summary>
        private void AddProduit()
        {
            //A Terminer Sotckoperation manque binding textbox modal
            Produit p = new Produit();
            p.Code = Code;
            p.Libelle = Libelle;
            p.Description = Description ;
            p.Actif = Actif;
            p.Stock = Stock;
            p.Prix = Prix;
            p.CategorieId = Categorie;
            Manager.Instance.AjouterProduit(p);

            LogProduit lp = new LogProduit();
            lp.Message = "Ajouter";
            lp.Date = DateTime.Now;
            lp.ProduitId = p.Id;
            Manager.Instance.AjouterLogProduit(lp);

            MettreAJourLaListeDeProduits();
            addProduitWindow.Close();
        }


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
        public void MettreAJourLaListeDeProduits()
        {
            Produits.Clear();
            foreach (Produit p in Manager.Instance.GetAllProduit())
            {
                Produits.Add(new DetailProduitViewModel(p));
            }

            if (Produits != null && Produits.Count > 0)
                SelectedProduit = Produits.ElementAt(0);
        }

        /// <summary>
        /// Commande pour supprimer des produits
        /// </summary>
        public ICommand DeleteProduits
        {
            get
            {
                if (_deleteProduits == null)
                    _deleteProduits = new RelayCommand(() => this.DeleteSelectedProduit());
                return _deleteProduits;
            }
        }

        /// <summary>
        /// Supprime selectedProduit
        /// </summary>
        public void DeleteSelectedProduit()
        {
            Manager.Instance.SupprimerProduit(SelectedProduit.Id);

            MettreAJourLaListeDeProduits();
        }

        /// <summary>
        /// Commande pour filtrer la liste des produits
        /// </summary>
        public ICommand BtnRechercheProduit
        {
            get
            {
                if (_btnRechercheProduit == null)
                    _btnRechercheProduit = new RelayCommand(() => this.RechercheProduits());
                return _btnRechercheProduit;
            }
        }

        /// <summary>
        /// Filtre la liste de produit
        /// </summary>
        public void RechercheProduits()
        {
            Produits.Clear();
            List<Produit> produitsFiltre = Manager.Instance.GetAllProduit().Where(x => x.Libelle.Contains(FiltreProduits)).ToList();
            foreach (Produit p in produitsFiltre)
            {
                Produits.Add(new DetailProduitViewModel(p));
            }

            if (Produits != null && Produits.Count > 0)
                SelectedProduit = Produits.ElementAt(0);
        }
        

        #endregion
    }
}
