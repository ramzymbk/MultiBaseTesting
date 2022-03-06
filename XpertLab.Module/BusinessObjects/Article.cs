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
    [NavigationItem("Stock")]
    [XafDefaultProperty("Nom")]

    public class Article : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Article(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        Categorie_Article categorie;
        string codeBarre;
        string refInterne;
        string conditionnement;
        string dosage;
        string unite;
        int stockMin;
        decimal prixVente;
        decimal prixAchat;
        bool achete;
        bool vendu;
        Forme_Article forme;
        string nom;
        int oid;

        [Key(AutoGenerate = true)]
        [Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }

        [Size(150)]
        [RuleUniqueValue]
        [XafDisplayName("Désignation"), ToolTip("Désignation d'article")]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }


        public Categorie_Article Categorie
        {
            get => categorie;
            set => SetPropertyValue(nameof(Categorie), ref categorie, value);
        }


        [Size(100)]
        [RuleUniqueValue]
        [XafDisplayName("Référence interne")]
        public string RefInterne
        {
            get => refInterne;
            set => SetPropertyValue(nameof(RefInterne), ref refInterne, value);
        }


        [Size(200)]
        [RuleUniqueValue]
        [XafDisplayName("Code Barre")]
        public string CodeBarre
        {
            get => codeBarre;
            set => SetPropertyValue(nameof(CodeBarre), ref codeBarre, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Dosage
        {
            get => dosage;
            set => SetPropertyValue(nameof(Dosage), ref dosage, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Unite
        {
            get => unite;
            set => SetPropertyValue(nameof(Unite), ref unite, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Conditionnement
        {
            get => conditionnement;
            set => SetPropertyValue(nameof(Conditionnement), ref conditionnement, value);
        }
        public Forme_Article Forme
        {
            get => forme;
            set => SetPropertyValue(nameof(Forme), ref forme, value);
        }

        [XafDisplayName("Peut être vendu")]
        public bool Vendu
        {
            get => vendu;
            set => SetPropertyValue(nameof(Vendu), ref vendu, value);
        }

        [XafDisplayName("Peut être acheté")]
        public bool Achete
        {
            get => achete;
            set => SetPropertyValue(nameof(Achete), ref achete, value);
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [XafDisplayName("Prix d'achat")]
        public decimal PrixAchat
        {
            get => prixAchat;
            set => SetPropertyValue(nameof(PrixAchat), ref prixAchat, value);
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [XafDisplayName("Prix de vente")]
        public decimal PrixVente
        {
            get => prixVente;
            set => SetPropertyValue(nameof(PrixVente), ref prixVente, value);
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [XafDisplayName("Stock Min")]
        public int StockMin
        {
            get => stockMin;
            set => SetPropertyValue(nameof(StockMin), ref stockMin, value);
        }

    }
}