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
using XpertLab.Module.XpertOutils;

namespace XpertLab.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Analyse")]
    [XafDefaultProperty("Num")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Dossier : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Dossier(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Date = XpertHelper.GetDate();

        }

        Medecin medecin;
        string conclusion;
        decimal totRemise;
        decimal totPrix;
        decimal totCout;
        decimal totTTC;
        string analysesDemandees;
        int oid;

        Etat etat;
        string codeBarre;
        decimal versement;


        DateTime date;
        Patient patient;
        string num;

        [Key(AutoGenerate = true)]
        [Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }

        [Size(XpertSizeAttribute.NumDocument)]
        [ModelDefault("AllowEdit", "False")]
        public string Num
        {
            get => num;
            set => SetPropertyValue(nameof(Num), ref num, value);
        }

        [RuleRequiredField]
        public Patient Patient
        {
            get => patient;
            set => SetPropertyValue(nameof(Patient), ref patient, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Médecin traitant")]
        [Size(100)]
        public Medecin Medecin
        {
            get => medecin;
            set => SetPropertyValue(nameof(Medecin), ref medecin, value);
        }

        [XafDisplayName("Code barre")]
        [Size(200)]
        public string CodeBarre
        {
            get => codeBarre;
            set => SetPropertyValue(nameof(CodeBarre), ref codeBarre, value);
        }


        public Etat Etat
        {
            get => etat;
            set => SetPropertyValue(nameof(Etat), ref etat, value);
        }

        //[RuleRequiredField]
        [XafDisplayName("Analyses demandées")]
        [Association("Dossier-DossiDetails")]
        public XPCollection<Dossier_Detail> DossiDetails
        {
            get
            {
                return GetCollection<Dossier_Detail>(nameof(DossiDetails));
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AnalysesDemandees
        {
            get
            {
                if (DossiDetails != null)
                    analysesDemandees = string.Join(", ", DossiDetails.Select(t => t.NomAnalyse).ToArray());
                else
                    analysesDemandees = "N/A";

                return analysesDemandees;
            }
            set => SetPropertyValue(nameof(AnalysesDemandees), ref analysesDemandees, value);
        }

        [XafDisplayName("Total vente")]
        public decimal TotPrix
        {
            get
            {
                if (!(DossiDetails == null))
                    totPrix = DossiDetails.Sum(x => x.Prix);
                return totPrix;
            }
            set => SetPropertyValue(nameof(TotPrix), ref totPrix, value);
        }

        [XafDisplayName("Total remise")]
        public decimal TotRemise
        {
            get
            {
                if (!(DossiDetails == null))
                    totRemise = DossiDetails.Sum(x => x.Remise);
                return totRemise;
            }
            set => SetPropertyValue(nameof(TotRemise), ref totRemise, value);
        }

        [VisibleInListView(false), VisibleInDetailView(false)]
        public decimal TotCout
        {
            get
            {
                if (!(DossiDetails == null))
                    totCout = DossiDetails.Sum(x => x.Cout);
                return totCout;
            }
            set => SetPropertyValue(nameof(TotCout), ref totCout, value);
        }

        [XafDisplayName("Total TTC")]
        public decimal TotTTC
        {
            get
            {
                totTTC = totPrix - totRemise;
                return totTTC;
            }
            set => SetPropertyValue(nameof(TotTTC), ref totTTC, value);
        }

        protected override void OnLoaded()
        {
            Reset();
            base.OnLoaded();
        }
        private void Reset()
        {
            totCout = 0;
            totRemise = 0;
            totPrix = 0;
            totTTC = 0;
        }


        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Versement
        {
            get => versement;
            set => SetPropertyValue(nameof(Versement), ref versement, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Conclusion
        {
            get => conclusion;
            set => SetPropertyValue(nameof(Conclusion), ref conclusion, value);
        }

        [VisibleInDetailView(false),VisibleInListView(false)]
        public XPCollection<Parametre_Analyse> Parametre_Analyse_List { get; set; }

        [VisibleInDetailView(false), VisibleInListView(false)]
        public XPCollection<Categorie_Analyse> Categorie_Analyses { get; set; }

        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null)
               && Session.IsNewObject(this)
                   && string.IsNullOrEmpty(Num))
            {

                int nextSequence = XpertGeneratorHelperID.Generate(Session, this.GetType().Name, "MyServerPrefix");
                Num = string.Format("D{0:D6}", nextSequence);
            }
            base.OnSaving();
        }

    }

    public enum Etat
    {
        Nouveau = 0,
        En_Instance = 1,
        Resultat_Rapporté = 2,
        Archivé = 3
    }
}