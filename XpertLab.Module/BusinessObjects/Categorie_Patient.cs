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
    [XafDisplayName("Catégorie de patient")]
    [NavigationItem("Patient")]
    [XafDefaultProperty("Nom")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Categorie_Patient : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Categorie_Patient(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        double tauxRemise;
        string nom;

        [Size(100)]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }

        [XafDisplayName("Taux de remise")]
        public double TauxRemise
        {
            get => tauxRemise;
            set => SetPropertyValue(nameof(TauxRemise), ref tauxRemise, value);
        }

    }
}