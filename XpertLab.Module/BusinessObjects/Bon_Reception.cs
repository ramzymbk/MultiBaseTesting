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
using Xpert.Common.Base.Persistent;
using XpertLab.Module.XpertOutils;

namespace XpertLab.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Bon de réception")]
    [NavigationItem("Stock")]
    [ImageName("BO_Vendor")]
    public class Bon_Reception : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Bon_Reception(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        decimal remiseGlobal;
        DateTime date;
        Fournisseur fournisseur;
        string num;
        int oid;

        [Key(AutoGenerate = true)]
        [Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }

        [Size(10)]
        //[ModelDefault("AllowEdit", "False")]
        [XafDisplayName("N° Réception")]
        public string Num
        {
            get => num;
            set => SetPropertyValue(nameof(Num), ref num, value);
        }


        public Fournisseur Fournisseur
        {
            get => fournisseur;
            set => SetPropertyValue(nameof(Fournisseur), ref fournisseur, value);
        }

        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Remise Global")]
        [ModelDefault("DisplayFormat", XpertFormat.FormatMoney), ModelDefault("EditMask", "n2")]
        
        public decimal RemiseGlobal
        {
            get => remiseGlobal;
            set => SetPropertyValue(nameof(RemiseGlobal), ref remiseGlobal, value);
        }

        [Association("Bon_Reception-BR_Details")]
        public XPCollection<Bon_Reception_Detail> BR_Details
        {
            get
            {
                return GetCollection<Bon_Reception_Detail>(nameof(BR_Details));
            }
        }

        //[XafDisplayName("Total vente")]
        //public decimal TotPrix
        //{
        //    get
        //    {
        //        if (!(DossiDetails == null))
        //            totPrix = DossiDetails.Sum(x => x.Prix);
        //        return totPrix;
        //    }
        //    set => SetPropertyValue(nameof(TotPrix), ref totPrix, value);
        //}


    }
}