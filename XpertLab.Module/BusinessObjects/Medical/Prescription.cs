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

    public class Prescription : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Prescription(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Visite visite;
        string posologie;
        Article medicament;

        public Article Medicament
        {
            get => medicament;
            set => SetPropertyValue(nameof(Medicament), ref medicament, value);
        }


        [Size(100)]
        public string Posologie
        {
            get => posologie;
            set => SetPropertyValue(nameof(Posologie), ref posologie, value);
        }

        
        [Association("Visite-Prescriptions")]
        [VisibleInListView(false),VisibleInDetailView(false)]
        public Visite Visite
        {
            get => visite;
            set => SetPropertyValue(nameof(Visite), ref visite, value);
        }

    }
}