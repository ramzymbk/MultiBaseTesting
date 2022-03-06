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
    [XafDefaultProperty("Libellé")]

    public class Antecedent : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Antecedent(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Patient patient;
        TypeAntecedent type;
        DateTime dateDebut;
        string description;
        string libellé;

        [XafDisplayName("Type antécédent")]
        public TypeAntecedent Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Libellé
        {
            get => libellé;
            set => SetPropertyValue(nameof(Libellé), ref libellé, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }


        public DateTime DateDebut
        {
            get => dateDebut;
            set => SetPropertyValue(nameof(DateDebut), ref dateDebut, value);
        }

        [Association("Antecedent-Traitements")]
        public XPCollection<Traitement> Traitements
        {
            get
            {
                return GetCollection<Traitement>(nameof(Traitements));
            }
        }

        
        [Association("Patient-Antecedents")]
        public Patient Patient
        {
            get => patient;
            set => SetPropertyValue(nameof(Patient), ref patient, value);
        }

    }
}