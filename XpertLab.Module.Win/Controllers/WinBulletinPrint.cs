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
using DevExpress.Persistent.Validation;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xpert.Common.Base.Helper;
using XpertLab.Module.BusinessObjects;
//using XpertERP.Module.BusinessObjects.HumanRessources;
using XpertLab.Module.Controllers;

namespace XpertLab.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class WinBulletinPrint : PrintTicketPrelController
    {
        protected override void PrintReport(IReportDataV2 reportData, Dossier obj)
        {
            if(XpertHelper.IsNullOrEmpty(obj.Oid))
            {
                return;
            }
            else 
            { 
            XtraReport report = ReportDataProvider.ReportsStorage.LoadReport(reportData);
           
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
                if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
                {
                    reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report);
                    report.Parameters["NumDoc"].Value = obj.Num;
                    report.RequestParameters = false;
                    ReportPrintTool printTool = new ReportPrintTool(report);

                    printTool.AutoShowParametersPanel = false;
                    printTool.ShowPreviewDialog();
                }
               
            }
        }
    }
}
