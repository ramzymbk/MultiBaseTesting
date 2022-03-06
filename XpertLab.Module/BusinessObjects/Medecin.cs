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
    [XafDefaultProperty("FullName")]

    public class Medecin : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Medecin(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string fullName;
        string adresse;
        string tel;
        string specialite;
        string prenom;
        string nom;
        int oid;

        [Key(AutoGenerate = true)]
        [Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Prenom
        {
            get => prenom;
            set => SetPropertyValue(nameof(Prenom), ref prenom, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [VisibleInListView(false), VisibleInDetailView(false)]
        public string FullName
        {
            get
            {
                fullName = "Dr "+ nom + " " + prenom;
                return fullName;
            }
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Specialite
        {
            get => specialite;
            set => SetPropertyValue(nameof(Specialite), ref specialite, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Tel
        {
            get => tel;
            set => SetPropertyValue(nameof(Tel), ref tel, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adresse
        {
            get => adresse;
            set => SetPropertyValue(nameof(Adresse), ref adresse, value);
        }

    }
}