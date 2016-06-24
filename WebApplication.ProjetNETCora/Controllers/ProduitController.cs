using BusinessLayer.ProjetNETCora;
using Modele.ProjetNETCora.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.ProjetNETCora.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            List<Categorie> categories = Manager.Instance.GetAllCategorie();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(Categorie cat in categories){
                items.Add(new SelectListItem { Text = cat.Libelle, Value = cat.Id.ToString() });
            }
            ViewBag.Categories = items;

            List<Produit> produits = Manager.Instance.GetAllProduit();

            return View(produits);  
        }

        // GET: Detail Produit
        public ActionResult Details(int id)
        {
            return View(Manager.Instance.GetByIdProduit(id));
        }

        // GET: Produit
        public ActionResult Edit(int id)
        {
            Produit produitAEditer = Manager.Instance.GetByIdProduit(id);
            return View(produitAEditer);
        }

        // POST: Produit
        [HttpPost]
        public ActionResult Edit(Produit p)
        {
            Produit produit = Manager.Instance.GetByIdProduit(p.Id);

            if (!ModelState.IsValid)
            {
                return View(produit);
            }
            produit.Code = p.Code;
            produit.Libelle = p.Libelle;
            produit.Description = p.Description;
            produit.Actif = p.Actif;
            produit.Stock = p.Stock;
            produit.Prix = p.Prix;
            produit.CategorieId = p.CategorieId;
            Manager.Instance.ModifierProduit(produit);

            return RedirectToAction("Index");
        }

        // POST: Recherche
        [HttpPost]
        public ActionResult Recherche(int? selectedCategorie, string selectedNom)
        {

            //Travailler avec une view model que l'on binde dans la vue donc
            //@model ViewModelProduit
            //et Model.Liste() pour le foreach
            //puis dans recherche
            //faire le filtre dessus

            List<Categorie> categories = Manager.Instance.GetAllCategorie();

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Aucune", Value = "0" });
            foreach (Categorie cat in categories)
            {
                items.Add(new SelectListItem { Text = cat.Libelle, Value = cat.Id.ToString() });
            }
            ViewBag.Categories = items;


            List<Produit> produits = Manager.Instance.GetAllProduit();
            produits = produits.Where(p => p.CategorieId == selectedCategorie && p.Libelle.Contains("/" + selectedNom + "/")).ToList();
            
            //Temporaire, fonctionne pas logique pas de vue recherche
            return View(produits);
        }

        // GET: /Produit/Create 
        public ActionResult Create()
        {
            return View();
        }  

        // POST: /Produit/Create 
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Manager.Instance.AjouterProduit(produit);

            return RedirectToAction("Index");
        } 


    }
}