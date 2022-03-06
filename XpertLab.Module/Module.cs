﻿using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.ReportsV2;
using XpertLab.Module.BusinessObjects;

namespace XpertLab.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class XpertLabModule : ModuleBase {
        public XpertLabModule() {
            InitializeComponent();
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);

            PredefinedReportsUpdater reportsupdater = new PredefinedReportsUpdater(Application, objectSpace, versionFromDB);

            reportsupdater.AddPredefinedReport<XRTiketPrelevement>("Ticket prélèvement", typeof(Dossier));
            reportsupdater.AddPredefinedReport<XRResultat>("Rapport résultat", typeof(Dossier));
            reportsupdater.AddPredefinedReport<XREntete>("Entête", typeof(ConfigLabo));
            reportsupdater.AddPredefinedReport<XREnteteTicket>("Entête tiket", typeof(ConfigLabo));

            return new ModuleUpdater[] { updater , reportsupdater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
