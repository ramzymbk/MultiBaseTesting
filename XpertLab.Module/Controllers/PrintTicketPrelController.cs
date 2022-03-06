using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xpert.Common.Base.Helper;
using XpertLab.Module.BusinessObjects;

namespace XpertLab.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public abstract partial class PrintTicketPrelController : ObjectViewController<ObjectView, Dossier>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/

        public SimpleAction ActPrintTicketPrelev;
        public SimpleAction ActPrintResultat;
        public PrintTicketPrelController()
        {
            InitializeComponent();

            // Target required Views (via the TargetXXX properties) and create their Actions.

            Dossier obj = null;
            ActPrintTicketPrelev = new SimpleAction(this, "PrintTicketPrel", PredefinedCategory.Edit)
            {
                Caption = "Imprimer Ticket de prélèvement",
                ImageName = "Action_Printing_Print"
            };
            ActPrintTicketPrelev.Execute += delegate (object sender, SimpleActionExecuteEventArgs e) {
                if (XpertHelper.IsNotNullAndNotEmpty(e.CurrentObject))
                {
                    if (e.CurrentObject is Dossier)
                    {
                        obj = (e.CurrentObject as Dossier);
                    }
                }
                IObjectSpace objectSpace = ReportDataProvider.ReportObjectSpaceProvider.CreateObjectSpace(typeof(ReportDataV2));
                IReportDataV2 reportData = objectSpace.FirstOrDefault<ReportDataV2>
                (data => data.PredefinedReportType == typeof(XRTiketPrelevement));

                if (reportData == null)
                {
                    throw new UserFriendlyException("Cannot find the 'XRTiketPrelevement' report.");
                }
                else
                {
                    PrintReport(reportData, obj);
                }
            };

            // action print resultat

            ActPrintResultat = new SimpleAction(this, "PrintResultat", PredefinedCategory.Edit)
            {
                Caption = "Imprimer Resultat",
                ImageName = "PrintArea"
            };
            ActPrintResultat.Execute += delegate (object sender, SimpleActionExecuteEventArgs e) {
                if (XpertHelper.IsNotNullAndNotEmpty(e.CurrentObject))
                {
                    if (e.CurrentObject is Dossier)
                    {
                        obj = (e.CurrentObject as Dossier);
                    }
                }
                IObjectSpace objectSpace = ReportDataProvider.ReportObjectSpaceProvider.CreateObjectSpace(typeof(ReportDataV2));
                IReportDataV2 reportData = objectSpace.FirstOrDefault<ReportDataV2>
                (data => data.PredefinedReportType == typeof(XRResultat));

                if (reportData == null)
                {
                    throw new UserFriendlyException("Cannot find the 'XRResultat' report.");
                }
                else
                {
                    PrintReport(reportData, obj);
                }
            };

        }
        protected abstract void PrintReport(IReportDataV2 reportData, Dossier obj);
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
