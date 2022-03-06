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
//using XpertERP.Module.BusinessObjects.HumanRessources;

namespace XpertLab.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public abstract partial class PrintTicketController : ObjectViewController<ObjectView, Dossier>
    {
        public SimpleAction ActPrintTicketPrelev;
        public PrintTicketController()
        {
            Dossier obj = null;
            ActPrintTicketPrelev = new SimpleAction(this, "Print_Bulletin", PredefinedCategory.Print)
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
        }
        protected abstract void PrintReport(IReportDataV2 reportData, Dossier obj);


    }
}
