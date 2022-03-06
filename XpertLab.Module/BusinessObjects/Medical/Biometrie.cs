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
    [XafDefaultProperty("Libelle")]
 
    public class Biometrie : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Biometrie(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Patient patient;
        string unite;
        string norme;
        double valeur;
        string libelle;
        TypeBiometrie type;

        [XafDisplayName("Type de biométrie")]
        public TypeBiometrie Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Libelle
        {
            get => libelle;
            set => SetPropertyValue(nameof(Libelle), ref libelle, value);
        }


        public double Valeur
        {
            get => valeur;
            set => SetPropertyValue(nameof(Valeur), ref valeur, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Norme
        {
            get => norme;
            set => SetPropertyValue(nameof(Norme), ref norme, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Unite
        {
            get => unite;
            set => SetPropertyValue(nameof(Unite), ref unite, value);
        }

        [VisibleInListView(false),VisibleInDetailView(false)]
        [Association("Patient-Biometries")]
        public Patient Patient
        {
            get => patient;
            set => SetPropertyValue(nameof(Patient), ref patient, value);
        }

    }
}