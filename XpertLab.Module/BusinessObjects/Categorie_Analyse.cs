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
    [XafDisplayName("Catégorie d'analyse")]
    [NavigationItem("Analyse")]
    [XafDefaultProperty("Nom")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Categorie_Analyse : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Categorie_Analyse(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Categorie_Mere categorieMere;
        int ordre;
        string nom;

        [Size(100)]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }


        public int Ordre
        {
            get => ordre;
            set => SetPropertyValue(nameof(Ordre), ref ordre, value);
        }

        [XafDisplayName("Catégorie Mère")]
        public Categorie_Mere CategorieMere
        {
            get => categorieMere;
            set => SetPropertyValue(nameof(CategorieMere), ref categorieMere, value);
        }

        [Association("Categorie_Analyse-Parametres")]
        public XPCollection<Parametre_Analyse> Parametres
        {
            get
            {
                return GetCollection<Parametre_Analyse>(nameof(Parametres));
            }
        }

    }
}