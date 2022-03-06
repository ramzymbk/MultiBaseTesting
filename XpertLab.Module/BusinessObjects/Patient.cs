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
using Xpert.Common.Base.Helper;

namespace XpertLab.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Patient")]
    [XafDefaultProperty("FullName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Patient : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Patient(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            age = 0;
        }


        string fullName;
        Sexe sexe;
        int age;
        string observation;
        string codeBarre;
        Categorie_Patient categoriePatient;
        string email;
        string tel;
        string adresse;
        DateTime dateNaissance;
        string prenom;
        string nom;

        [Size(100)]
        public string Nom
        {
            get => nom;
            set => SetPropertyValue(nameof(Nom), ref nom, value);
        }


        [Size(100)]
        public string Prenom
        {
            get => prenom;
            set => SetPropertyValue(nameof(Prenom), ref prenom, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]                         
        [VisibleInListView(false),VisibleInDetailView(false)]
        public string FullName
        {
            get { 
                fullName = nom + " "+ prenom;
                return fullName;
            }
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }

        [XafDisplayName("Date de naissance")]
        public DateTime DateNaissance
        {
            get => dateNaissance;
            set => SetPropertyValue(nameof(DateNaissance), ref dateNaissance, value);
        }


        public int Age
        {
            get
            {
                DateTime date = XpertHelper.GetDate();
                age = (int)((DateTime.Now - dateNaissance).TotalDays / 365.242199);//age = // date - dateNaissance;
                return age;
            }
            set => SetPropertyValue(nameof(Age), ref age, value);
        }

        
        public Sexe Sexe
        {
            get => sexe;
            set => SetPropertyValue(nameof(Sexe), ref sexe, value);
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


        [Size(100)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [XafDisplayName("Catégorie de patient")]
        public Categorie_Patient CategoriePatient
        {
            get => categoriePatient;
            set => SetPropertyValue(nameof(CategoriePatient), ref categoriePatient, value);
        }

        [XafDisplayName("Code barre")]
        [Size(200)]
        public string CodeBarre
        {
            get => codeBarre;
            set => SetPropertyValue(nameof(CodeBarre), ref codeBarre, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Observation
        {
            get => observation;
            set => SetPropertyValue(nameof(Observation), ref observation, value);
        }

        [Association("Patient-Antecedents")]
        public XPCollection<Antecedent> Antecedent
        {
            get
            {
                return GetCollection<Antecedent>(nameof(Antecedent));
            }
        }

        [Association("Patient-Biometries")]
        [XafDisplayName("Biométrie")]
        public XPCollection<Biometrie> Biometries
        {
            get
            {
                return GetCollection<Biometrie>(nameof(Biometries));
            }
        }

        [Association("Patient-RendezVous")]
        public XPCollection<RendezVous> RendezVous
        {
            get
            {
                return GetCollection<RendezVous>(nameof(RendezVous));
            }
        }



    }

    public enum Sexe
    {
        Homme = 0,
        Femme = 1
              
    }
}