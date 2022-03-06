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
    [NavigationItem("Medical")]

    public class Visite : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Visite(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        decimal honoraire;
        string conclusion;
        string description;
        DateTime date;
        string titre;
        Patient patient;

        public Patient Patient
        {
            get => patient;
            set => SetPropertyValue(nameof(Patient), ref patient, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Titre
        {
            get => titre;
            set => SetPropertyValue(nameof(Titre), ref titre, value);
        }


        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Conclusion
        {
            get => conclusion;
            set => SetPropertyValue(nameof(Conclusion), ref conclusion, value);
        }

        
        public decimal Honoraire
        {
            get => honoraire;
            set => SetPropertyValue(nameof(Honoraire), ref honoraire, value);
        }

        [Association("Visite-Prescriptions")]
        public XPCollection<Prescription> Prescriptions
        {
            get
            {
                return GetCollection<Prescription>(nameof(Prescriptions));
            }
        }

    }
}