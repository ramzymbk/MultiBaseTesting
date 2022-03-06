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
    [NavigationItem("Stock")]
    [XafDisplayName("Détails Bon de réception")]

    public class Bon_Reception_Detail : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Bon_Reception_Detail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Bon_Reception bonReception;
        decimal mtAchat;
        decimal remise;
        decimal prixAchat;
        int qteCommande;
        int quantite;
        Article article;
        int oid;

        [Key(AutoGenerate = true)]
        [Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }


        public Article Article
        {
            get => article;
            set
            {
                if (SetPropertyValue(nameof(Article), ref article, value) && !IsLoading && !IsSaving)
                {
                    prixAchat = article.PrixAchat;
                    OnChanged(nameof(PrixAchat));
                }//=> SetPropertyValue(nameof(Article), ref article, value);
            }
        }


        public int Quantite
        {
            get => quantite;
            set => SetPropertyValue(nameof(Quantite), ref quantite, value);
        }


        public int QteCommande
        {
            get => qteCommande;
            set => SetPropertyValue(nameof(QteCommande), ref qteCommande, value);
        }


        public decimal PrixAchat
        {
            get => prixAchat;
            set => SetPropertyValue(nameof(PrixAchat), ref prixAchat, value);
        }


        public decimal Remise
        {
            get => remise;
            set => SetPropertyValue(nameof(Remise), ref remise, value);
        }


        public decimal MtAchat
        {
            get
            {
                mtAchat = (prixAchat - remise) * quantite;
                return mtAchat;
            }
            //set => SetPropertyValue(nameof(MtAchat), ref mtAchat, value);
        }

        
        [Association("Bon_Reception-BR_Details")]
        [VisibleInListView(false),VisibleInDetailView(false)]
        public Bon_Reception BonReception
        {
            get => bonReception;
            set => SetPropertyValue(nameof(BonReception), ref bonReception, value);
        }


    }
}