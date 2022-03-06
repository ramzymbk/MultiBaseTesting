using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XpertLab.Module.BusinessObjects;
using System.Windows.Forms;
using XpertLab.Module.BusinessObjects;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ListView = DevExpress.ExpressApp.ListView;

namespace XpertLab.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CategorieAnalyse_Controller : ListViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CategorieAnalyse_Controller()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            View.SelectionChanged += selectionChanged;
            View.ControlsCreated += View_ControlsCreated;
            View.SelectionTypeChanged += View_SelectionTypeChanged;

            // Perform various tasks depending on the target View.
        }

        private void View_SelectionTypeChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();


        }

        private void View_ControlsCreated(object sender, EventArgs e)
        {
            base.OnViewControlsCreated();

            ListView listview_Category = sender as ListView;

            DetailView Dossier_View = listview_Category?.ObjectSpace?.Owner as DetailView;

            if (Dossier_View?.Id == "Dossier_DetailView_Popup")
            {

                Control control = listview_Category.Control as Control;
                string name = control.Name;
                GridControl gridControl = GetControl(control, null) as GridControl;
                GridView gridView = (gridControl?.MainView as GridView);
                gridView.SelectionChanged += GridView_SelectionChanged;


                Dossier dossier = Dossier_View.CurrentObject as Dossier;


            }
        }

    
        private void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DevExpress.ExpressApp.Win.Editors.XafGridView gridView = sender as DevExpress.ExpressApp.Win.Editors.XafGridView;
            if (gridView != null && e != null && e.Action == System.ComponentModel.CollectionChangeAction.Refresh )
            {
                gridView.ClearSelection();
            }


        }

        private void selectionChanged(object sender, EventArgs e)
        {
            if (sender != null)
             {
                ListView ListView_Selected = sender as ListView;

                if (ListView_Selected.Id == "Dossier_Categorie_Analyses_ListView")
                {
                    DetailView Dossier_View = ListView_Selected?.ObjectSpace?.Owner as DetailView;
                    if (Dossier_View?.Id == "Dossier_DetailView_Popup")
                    {

                        ListPropertyEditor listviewCategorie_Analyses = (Dossier_View).FindItem(nameof(Dossier.Categorie_Analyses)) as ListPropertyEditor;
                        Dossier dossier = Dossier_View.CurrentObject as Dossier;
                        List<Categorie_Analyse> Categorie_Analyses = new List<Categorie_Analyse>();

                        foreach (Object itemLIst in listviewCategorie_Analyses.ListView.SelectedObjects)
                        {
                            Categorie_Analyses.Add((Categorie_Analyse)itemLIst);
                        }


                        ViewItem listview_Param = (Dossier_View).FindItem(nameof(Dossier.Parametre_Analyse_List)) as ViewItem;
                        Control control = listview_Param.Control as Control;
                        GridControl gridControl = GetControl(control, null) as GridControl;
                        GridView gridView = (gridControl?.MainView as GridView);

                        if (gridView != null)
                        {
                            List<Parametre_Analyse> Parametre_Analyse_List = new List<Parametre_Analyse>();
                            ListPropertyEditor Param_ListPropertyEditor = listview_Param as ListPropertyEditor;
                            for (int i = 0; i < gridView.RowCount; i++)
                            {
                                Parametre_Analyse parametre_Analysem = gridView.GetRow(i) as Parametre_Analyse;
                                if (Categorie_Analyses.Contains(parametre_Analysem.Categorie))
                                {
                                    (gridControl.MainView as GridView).GetDataRow(i);


                                    gridView.SelectRow(i);
                                }
                                else
                                {
                                    (gridControl.MainView as GridView).UnselectRow(i);

                                }
                            }

                        }

                    }
                }
                else if(ListView_Selected.Id== nameof(Dossier.Parametre_Analyse_List))
                {

                }

                


            }

        }

        private Control GetControl(Control _control, GridControl gridControl)
        {
            if (_control is GridControl)
            {
                gridControl = (_control as GridControl);
                return gridControl;
            }
            foreach (Control item in _control?.Controls)
            {

                if (item.HasChildren)
                {
                    gridControl = GetControl(item, gridControl) as GridControl;
                    if (gridControl != null)
                    {
                        return gridControl;
                    }
                }
                if (_control is GridControl)
                {
                    gridControl = (_control as GridControl);
                    return gridControl;
                }
            }
            return gridControl;
        }



        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
