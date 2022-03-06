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
    [NavigationItem("Paramétrage")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ConfigLabo : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ConfigLabo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string email;
        string tel;
        string adresse;
        byte[] logo;
        string specialite;
        string gerant;
        string nomLab;

        [XafDisplayName("Nom du laboratoire")]
        [Size(200)]
        public string NomLab
        {
            get => nomLab;
            set => SetPropertyValue(nameof(NomLab), ref nomLab, value);
        }


        [Size(100)]
        public string Gerant
        {
            get => gerant;
            set => SetPropertyValue(nameof(Gerant), ref gerant, value);
        }


        [Size(100)]
        public string Specialite
        {
            get => specialite;
            set => SetPropertyValue(nameof(Specialite), ref specialite, value);
        }

        [ImageEditor]
        public byte[] Logo
        {
            get => logo;
            set => SetPropertyValue(nameof(Logo), ref logo, value);
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

    }
}