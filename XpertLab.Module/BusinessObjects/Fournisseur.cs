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
using Xpert.Common.Base.Persistent;

namespace XpertLab.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDefaultProperty("Nom")]
    [NavigationItem("Table de base")]
    public class Fournisseur : XpertBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Fournisseur(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }



        string email;
        string tel;
        string adresse;
        bool actif;
        string nom;

        [Size(150)]
        [RuleUniqueValue]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }

        [XafDisplayName("Actif")]
        public bool Actif
        {
            get => actif;
            set => SetPropertyValue(nameof(Actif), ref actif, value);
        }


        [Size(300)]
        public string Adresse
        {
            get => adresse;
            set => SetPropertyValue(nameof(Adresse), ref adresse, value);
        }


        [Size(20)]
        public string Tel
        {
            get => tel;
            set => SetPropertyValue(nameof(Tel), ref tel, value);
        }

        
        [Size(50)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }


    }


}