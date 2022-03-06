using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XpertLab.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Paramètre d'analyse")]
    [NavigationItem("Analyse")]
    [XafDefaultProperty("Nom")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Parametre_Analyse : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Parametre_Analyse(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Categorie_Analyse categorie;
        int ordre;
        string valeurRef;
        string commentaire;
        decimal prix;
        decimal cout;
        Instrument instrument;
        string methode;
        Outil_Prelevement outilPrelevement;
        string uniteMesure;
        //Categorie_Analyse categorie;

        string alias;
        string nom;




        [Size(100)]
        [RuleRequiredField]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }


        [Size(100)]
        public string Alias
        {
            get => alias;
            set => SetPropertyValue(nameof(Alias), ref alias, value);
        }

        //[Persistent]
        public int Ordre
        {
            get => ordre;
            set => SetPropertyValue(nameof(Ordre), ref ordre, value);
        }

        //public Categorie_Analyse Categorie
        //{
        //    get => categorie;
        //    set => SetPropertyValue(nameof(Categorie), ref categorie, value);
        //}

        
        [Association("Categorie_Analyse-Parametres")]
        public Categorie_Analyse Categorie
        {
            get => categorie;
            set => SetPropertyValue(nameof(Categorie), ref categorie, value);
        }

        [XafDisplayName("Unité de mesure")]
        [Size(50)]
        public string UniteMesure
        {
            get => uniteMesure;
            set => SetPropertyValue(nameof(UniteMesure), ref uniteMesure, value);
        }

        [XafDisplayName("Valeur de référence")]
        [Size(200)]
        public string ValeurRef
        {
            get => valeurRef;
            set => SetPropertyValue(nameof(ValeurRef), ref valeurRef, value);
        }

        [XafDisplayName("Outil de prélèvement")]
        public Outil_Prelevement OutilPrelevement
        {
            get => outilPrelevement;
            set => SetPropertyValue(nameof(OutilPrelevement), ref outilPrelevement, value);
        }

        [XafDisplayName("Méthode d'analyse")]
        [Size(300)]
        public string Methode
        {
            get => methode;
            set => SetPropertyValue(nameof(Methode), ref methode, value);
        }


        public Instrument Instrument
        {
            get => instrument;
            set => SetPropertyValue(nameof(Instrument), ref instrument, value);
        }


        public decimal Cout
        {
            get => cout;
            set => SetPropertyValue(nameof(Cout), ref cout, value);
        }

        [XafDisplayName("Prix Vente")]
        public decimal Prix
        {
            get => prix;
            set => SetPropertyValue(nameof(Prix), ref prix, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Commentaire
        {
            get => commentaire;
            set => SetPropertyValue(nameof(Commentaire), ref commentaire, value);
        }

    }
}