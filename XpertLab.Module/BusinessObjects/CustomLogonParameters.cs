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
using System.Text.Json;
using Microsoft.Extensions.Options;


namespace Chooser.Module.BusinessObjects
{
    public interface IDatabaseNameParameter
    {
        string NameConfigDB
        {
            get;
            set;
        }
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
                _nameConfigDB =value;
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
        public string ConfigName
        {
            get;
            set;
        }
        public string ConfigString
        {
            get;
            set;
        }

    }
    public class ConnectionStrings
    {
        public List<string> CustomConnectionString { get; set; }

    }
    public class Root2
    {
        public ConnectionStrings ConnectionStrings
        {
            get;
            set;
        }
    }

    public class MSSqlServerChangeDatabaseHelper
    {



        public const string NameConfigDB = "Clinique;ERP;Lab;";
        public static string PatchConnectionString(string pNameConfig, string connectionString)
        {
            var myJsonResponse2 = File.ReadAllText(@"C:\Users\Ramzi\Documents\GitHub\MultiBaseTesting\XpertLab.Blazor.Server\appsettings.json");
            Root2 myDeserializedClass2 = JsonConvert.DeserializeObject<Root2>(myJsonResponse2);
            string cnn = "";
            foreach (var myConnectionString in myDeserializedClass2.ConnectionStrings.CustomConnectionString)
            {
                string[] myConnectionBrute = myConnectionString.Split(";", 2);
                ConfigDB myConnection = new ConfigDB
                {
                    ConfigName = myConnectionBrute[0],
                    ConfigString = myConnectionBrute[1],

                };
                if (!string.IsNullOrEmpty(myConnection.ConfigName) && myConnection.ConfigName == pNameConfig)
                {
                    cnn = myConnection.ConfigString;
                }
            }
            return cnn;
        }
    }
}