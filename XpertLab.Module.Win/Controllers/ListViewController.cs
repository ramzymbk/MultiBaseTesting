using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Views.Grid;
using ListView = DevExpress.ExpressApp.ListView;
using DevExpress.Persistent.BaseImpl;

namespace XpertLab.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ListViewController : ObjectViewController<ListView, BaseObject>
    {
        GridListEditor listEditor = null;
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.Reloaded += objspace_reloaded;
            View.SelectionChanged += View_SelectionChanged;

        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
        }

        protected override void OnDeactivated()
        {
            View.SelectionChanged -= View_SelectionChanged;
            ObjectSpace.Reloaded -= objspace_reloaded;
            base.OnDeactivated();
        }
        private void objspace_reloaded(object sender, EventArgs e)
        {
            //listEditor.GridView.ClearSelection();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            listEditor = ((ListView)View).Editor as GridListEditor;

            if (listEditor != null)
            {
                GridView gridView = listEditor.GridView;
                gridView.OptionsSelection.MultiSelect = true;
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                
            }
        }



    }
}
