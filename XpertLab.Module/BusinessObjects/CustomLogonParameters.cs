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
    #region
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
    #endregion

    #region 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ConnectionStrings
    {
        public List<string> CustomConnectionString { get; set; }
    }

    public class Root2
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }




    #endregion

    public class MSSqlServerChangeDatabaseHelper
    {







        public const string NameConfigDB = "XpertClinic;XpertLab";
        public static string PatchConnectionString(string pNameConfig, string connectionString)
        {


            var myJsonResponse = File.ReadAllText(@"C:\Users\Ramzi\Documents\GitHub\MultiBaseTesting\XpertLab.Module\BusinessObjects\MyLoginData.json");

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

            #region

            var myJsonResponse2 = File.ReadAllText(@"C:\Users\Ramzi\Documents\GitHub\MultiBaseTesting\XpertLab.Blazor.Server\appsettings.json");
            Root2 myDeserializedClass2 = JsonConvert.DeserializeObject<Root2>(myJsonResponse2);

            string cnn = "";
            foreach (var myConnectionString in myDeserializedClass2.ConnectionStrings.CustomConnectionString)
            {
                string[] myConnectionBrute = myConnectionString.Split(";");

                ConfigDB myConnection = new ConfigDB { ConfigName = myConnectionBrute[0], ServerName = myConnectionBrute[1], DatabaseName = myConnectionBrute[2], UserName = myConnectionBrute[3], Password = myConnectionBrute[4] };


                if (!string.IsNullOrEmpty(myConnection.ConfigName) && myConnection.ConfigName == pNameConfig)
                {
                    cnn = string.Format("Data Source={0};Initial Catalog ={1}; User ID ={2}; Password ={3}",
                                     myConnection.ServerName, myConnection.DatabaseName, myConnection.UserName, myConnection.Password);
                    return cnn;

                }
            }

            #endregion

            /*
                        foreach (var ItemConfig in myDeserializedClass.ListConfigDB)
                        {
                            if (ItemConfig != null)
                            {
                                if (!string.IsNullOrEmpty(ItemConfig.ConfigName) && ItemConfig.ConfigName == pNameConfig)
                                {

                                       // decryptage pwd
                                       cnn = string.Format($"{x}; User ID ={ItemConfig.UserName}; Password ={ItemConfig.Password}");
                                }
                            }
                        }
            */
            return cnn;
        }
    }
}
