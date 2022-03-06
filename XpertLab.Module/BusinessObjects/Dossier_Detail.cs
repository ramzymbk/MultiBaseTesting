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
    [NavigationItem("Analyse")]
    [XafDisplayName("Détail Dossier")]
    
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Dossier_Detail : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Dossier_Detail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
 
        }

        //Categorie_Analyse categorie;
        Dossier doss;
        string nomAnalyse;
        
        EtatDetail etat;
        decimal cout;
        decimal remise;
        decimal prix;
        decimal tTC;
        string observation;
        double valeur;
        Parametre_Analyse paramAnalyse;
        int oid;

        [Key(AutoGenerate = true)]
        [Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }

        
        //public Categorie_Analyse Categorie
        //{
        //    get => categorie;
        //    set => SetPropertyValue(nameof(Categorie), ref categorie, value);
        //}

        [XafDisplayName("Paramètre d'analyse")]
        [ImmediatePostData]
        [RuleRequiredField]
        public Parametre_Analyse ParamAnalyse
        {

            get => paramAnalyse;
            set
            {
                if (SetPropertyValue(nameof(ParamAnalyse), ref paramAnalyse, value) && !IsLoading && !IsSaving)
                {
                    cout = paramAnalyse.Cout;
                    prix = paramAnalyse.Prix;
                    tTC = prix;
                    nomAnalyse = paramAnalyse.Nom;
                    //categorie = paramAnalyse.Categorie;
                    OnChanged(nameof(Cout));
                    OnChanged(nameof(Prix));
                    OnChanged(nameof(TTC));
                    OnChanged(nameof(NomAnalyse));
                    //OnChanged(nameof(Categorie));
                }
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Browsable(false)]
        public string NomAnalyse
        {
            get => nomAnalyse;
            set => SetPropertyValue(nameof(NomAnalyse), ref nomAnalyse, value);
        }


        public double Valeur
        {
            get => valeur;
            set => SetPropertyValue(nameof(Valeur), ref valeur, value);
        }

        [Browsable(false)]
        public decimal Cout
        {
            get { return cout; }
            set => SetPropertyValue(nameof(Cout), ref cout, value);
        }


        [XafDisplayName("Prix Vente")]
        public decimal Prix
        {
            get { return prix; }
            set => SetPropertyValue(nameof(Prix), ref prix, value);
        }


        public decimal Remise
        {
            get { return remise; }
            set => SetPropertyValue(nameof(Remise), ref remise, value);
        }


        [XafDisplayName("Prix TTC")]
        public decimal TTC
        {
            get
            {
                tTC = prix - remise;
                return tTC;
            }
            set => SetPropertyValue(nameof(TTC), ref tTC, value);
        }

        
        [Association("Dossier-DossiDetails")]
        [VisibleInListView(false),VisibleInDetailView(false)]
        public Dossier Doss
        {
            get => doss;
            set => SetPropertyValue(nameof(Doss), ref doss, value);
        }
 
        [Size(SizeAttribute.Unlimited)]
        public string Observation
        {
            get => observation;
            set => SetPropertyValue(nameof(Observation), ref observation, value);
        }


        public EtatDetail Etat
        {
            get => etat;
            set => SetPropertyValue(nameof(Etat), ref etat, value);
        }
 
    }

    public enum EtatDetail
    {
        EnInstance = 0,
        ValideParTechnicien = 1,
        ValideParResponsable = 2
    }
}