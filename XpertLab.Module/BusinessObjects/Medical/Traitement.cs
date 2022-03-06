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
  
    public class Traitement : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Traitement(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Antecedent antecedent;
        Article medicament;
        string observation;
        string posologie;


        public Article Medicament
        {
            get => medicament;
            set => SetPropertyValue(nameof(Medicament), ref medicament, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Posologie
        {
            get => posologie;
            set => SetPropertyValue(nameof(Posologie), ref posologie, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Observation
        {
            get => observation;
            set => SetPropertyValue(nameof(Observation), ref observation, value);
        }

        
        [Association("Antecedent-Traitements")]
        [VisibleInListView(false),VisibleInDetailView(false)]
        public Antecedent Antecedent
        {
            get => antecedent;
            set => SetPropertyValue(nameof(Antecedent), ref antecedent, value);
        }


    }
}