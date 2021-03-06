using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Security.Strategy;
using Chooser.Module.BusinessObjects;

namespace XpertLab.Win
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Win.WinApplication._members
    public partial class XpertLabWindowsFormsApplication : WinApplication
    {
        private static Dictionary<string, bool> isCompatibilityChecked = new Dictionary<string, bool>();

        public XpertLabWindowsFormsApplication()
        {
            InitializeComponent();
            ((SecurityStrategyComplex)Security).Authentication = new AuthenticationStandard<SecuritySystemUser, CustomLogonParametersForStandardAuthentication>();
            //((SecurityStrategyComplex)Security).Authentication = new ChangeDatabaseActiveDirectoryAuthentication();
            SplashScreen = new DXSplashScreen(typeof(XafSplashScreen), new DefaultOverlayFormOptions());
        }

        protected override void OnLoggingOn(LogonEventArgs args)
        {
            base.OnLoggingOn(args);
            string targetConfigName = ((IDatabaseNameParameter)args.LogonParameters).NameConfigDB;
            ObjectSpaceProvider.ConnectionString = MSSqlServerChangeDatabaseHelper.PatchConnectionString(targetConfigName, ConnectionString);
        }
        protected override bool IsCompatibilityChecked
        {
            get
            {
                return isCompatibilityChecked.ContainsKey(ConnectionString) ? isCompatibilityChecked[ConnectionString] : false;
            }

            set
            {
                isCompatibilityChecked[ConnectionString] = value;
            }
        }
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProviders.Add(new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, XPObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection, false), false));
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }
        private void XpertLabWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e)
        {
            string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            if (userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1)
            {
                e.Languages.Add(userLanguageName);
            }
        }
        private void XpertLabWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e)
        {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if (System.Diagnostics.Debugger.IsAttached)
            {
                e.Updater.Update();
                e.Handled = true;
            }
            else
            {
                string message = "The application cannot connect to the specified database, " +
                    "because the database doesn't exist, its version is older " +
                    "than that of the application or its schema does not match " +
                    "the ORM data model structure. To avoid this error, use one " +
                    "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

                if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
                {
                    message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
                }
                throw new InvalidOperationException(message);
            }
#endif
        }
    }
}
