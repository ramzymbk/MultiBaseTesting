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
    [XafDefaultProperty("FullTime")]
 
    public class Horaire : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Horaire(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string fullTime;
        TimeSpan tempsFin;
        TimeSpan tempsDebut;

        
        public TimeSpan TempsDebut
        {
            get => tempsDebut;
            set => SetPropertyValue(nameof(TempsDebut), ref tempsDebut, value);
        }

        

        public TimeSpan TempsFin
        {
            get => tempsFin;
            set => SetPropertyValue(nameof(TempsFin), ref tempsFin, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [VisibleInListView(false), VisibleInDetailView(false)]
        public string FullTime
        {
            get
            {
                fullTime = tempsDebut + " - " + tempsFin;
                return fullTime;
            }
            set => SetPropertyValue(nameof(FullTime), ref fullTime, value);
        }

        

    }
}