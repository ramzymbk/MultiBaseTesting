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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NomConfig : BaseObject
    {
        public NomConfig(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string nomBD;
        string nomServeur;
        ProviderSelect provider;
        string nomConfiguration;
        private string password;
        private string userName;

        public string NomConfiguration
        {
            get => nomConfiguration;
            set => SetPropertyValue(nameof(NomConfiguration), ref nomConfiguration, value);
        }

        public ProviderSelect Provider
        {
            get => provider;
            set => SetPropertyValue(nameof(Provider), ref provider, value);
        }

        public string NomServeur
        {
            get => nomServeur;
            set => SetPropertyValue(nameof(NomServeur), ref nomServeur, value);
        }

        public string NomBD
        {
            get => nomBD;
            set => SetPropertyValue(nameof(NomBD), ref nomBD, value);
        }
        public string Password
        {
            get => password;
            set => SetPropertyValue(nameof(Password), ref password, value);
        }
        public string UserName
        {
            get => userName;
            set => SetPropertyValue(nameof(UserName), ref userName, value);
        }
    }
    public enum ProviderSelect
    {
        MSSQL_Server = 0,
        Oracle = 1,
        PostgreSQL = 2
    }
}