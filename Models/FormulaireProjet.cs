using System;
using System.ComponentModel.DataAnnotations;

namespace PromamecIntranet.Models
{
    public class FormulaireProjet
    {
        public int Id { get; set; }

        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [Display(Name = "N° Projet / Marché")]
        public string NumeroProjet { get; set; }

        [Display(Name = "N° Affaire(s)")]
        public string NumeroMarche { get; set; }

        [Display(Name = "Contrat N°")]
        public string NumeroContrat { get; set; }

        [Display(Name = "Nom du Client / Établissement")]
        public string NomClient { get; set; }

        [Display(Name = "Nom & Téléphone du Contact")]
        public string ContactClient { get; set; }

        [Display(Name = "Adresse de livraison")]
        public string AdresseLivraison { get; set; }

        [Display(Name = "Modalités de paiement Client")]
        public string ModalitePaiement { get; set; }

        [Display(Name = "Dernier délai de Livraison")]
        public DateTime? DelaiLivraison { get; set; }

        [Display(Name = "Dernier délai d'exécution")]
        public DateTime? DelaiExecution { get; set; }

        [Display(Name = "Durée de garantie")]
        public string DureeGarantie { get; set; }

        [Display(Name = "Détail Formation")]
        public string DetailFormation { get; set; }

        [Display(Name = "Dossier AMSSNUR requis")]
        public bool DossierAMSSNUR { get; set; }

        [Display(Name = "Contrat de maintenance à l'acquisition")]
        public bool ContratMaintenance { get; set; }

        public string Equipements { get; set; }
        public string Accessoires { get; set; }

        [Display(Name = "Travaux à la charge de Promamec")]
        public string TravauxPromamec { get; set; }

        public string Commentaires { get; set; }

        [Display(Name = "Nom du fichier Excel")]
        public string NomFichierExcel { get; set; }

        [Display(Name = "Chemin du fichier Excel")]
        public string CheminFichierExcel { get; set; }
    }
}
