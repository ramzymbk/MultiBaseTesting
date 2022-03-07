using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Helpers;
using System.Linq;
using XpertLab.Module.BusinessObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using DevExpress.DataAccess.Json;
using System;
using System.Collections.Generic;
using Json.Net;
using Newtonsoft.Json;
using System.Text.Json;

namespace Chooser.Module.BusinessObjects
{



    public interface IDatabaseNameParameter
    {
        string NameConfigDB { get; set; }
    }
    [DomainComponent]
    public class CustomLogonParametersForStandardAuthentication : AuthenticationStandardLogonParameters, IDatabaseNameParameter
    {
        private string _nameConfigDB = MSSqlServerChangeDatabaseHelper.NameConfigDB.Split(';')[0];
        [ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.NameConfigDB)]


        public string NameConfigDB
        {
            get
            {
                return _nameConfigDB;
            }
            set
            {
                _nameConfigDB = value;
            }
        }

    }
    [DomainComponent]
    public class CustomLogonParametersForActiveDirectoryAuthentication : IDatabaseNameParameter
    {
        private string _nameConfigDB = MSSqlServerChangeDatabaseHelper.NameConfigDB.Split(';')[0];

        [ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.NameConfigDB)]
        public string NameConfigDB
        {
            get
            {
                return _nameConfigDB;
            }
            set
            {
                _nameConfigDB = value;
            }
        }
    }

    public class ConfigDB
    {
        public string ConfigName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Root
    {
        public List<ConfigDB> ListConfigDB { get; set; }
    }
    public class MSSqlServerChangeDatabaseHelper
    {
        public const string NameConfigDB = "Home;Work1;Work2";
        public static string PatchConnectionString(string pNameConfig, string connectionString)
        {


            var myJsonResponse = File.ReadAllText(@"C:\Users\soufiane\Documents\GitHub\MultiBaseTesting\XpertLab.Module\BusinessObjects\MyLoginData.json");

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            string cnn = "";

            foreach (var ItemConfig in myDeserializedClass.ListConfigDB)
            {
                if (ItemConfig != null)
                {
                    if (!string.IsNullOrEmpty(ItemConfig.ConfigName) && ItemConfig.ConfigName == pNameConfig)
                    {
                        // decryptage pwd
                        cnn = string.Format("Data Source={0};Initial Catalog ={1}; User ID ={2}; Password ={3}",
                                ItemConfig.ServerName, ItemConfig.DatabaseName, ItemConfig.UserName, ItemConfig.Password);
                    }
                }
            }

            return cnn;
        }
    }
}
