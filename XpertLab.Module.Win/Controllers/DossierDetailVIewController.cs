using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XpertLab.Module.BusinessObjects;

namespace XpertLab.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class Dossier_DetailView_Win_Controller : ObjectViewController<DetailView, Dossier>
    {
        SimpleAction Valider;
        
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public Dossier_DetailView_Win_Controller()
        {
            InitializeComponent();

            // Action valider dans le popup pour valider la creation des analyses
            Valider = new SimpleAction(this, "Valider", PredefinedCategory.PopupActions)
            {
                Caption = "Valider",
                ConfirmationMessage = "Voulez vous ajouter les Analyses au client?",
            };
            Valider.Execute += ValiderParam;
          
            // action popup qui affiche le popup
            PopupWindowShowAction action = new PopupWindowShowAction(this, "Sélectionner les paramètres", PredefinedCategory.RecordEdit)
            {
                Caption = "Sélectionner les paramètres",
                ImageName = "ItemTypeChecked",
                
            };
            action.CustomizePopupWindowParams += Action_CustomizePopupWindowParams; ;
            action.SelectionDependencyType = SelectionDependencyType.Independent;
            Actions.Add(action);


        }


        private void Action_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            View.ObjectSpace.CommitChanges();

            #region 
            Dossier Details = (View.CurrentObject as Dossier);
            IObjectSpace objectSpacePoupUp = Application.CreateObjectSpace(typeof(Dossier));

            Dossier DetailsPopup = objectSpacePoupUp.GetObjectsQuery<Dossier>().Where(x => x.Oid == Details.Oid).FirstOrDefault();

            IList<Parametre_Analyse> parametre_Analyses = objectSpacePoupUp.GetObjects<Parametre_Analyse>().ToList();
            DetailsPopup.Parametre_Analyse_List = new XPCollection<Parametre_Analyse>(((XPObjectSpace)objectSpacePoupUp).Session, parametre_Analyses);
            #endregion

            IList<Categorie_Analyse> Categorie_Analyses = objectSpacePoupUp.GetObjects<Categorie_Analyse>().ToList();
            DetailsPopup.Categorie_Analyses = new XPCollection<Categorie_Analyse>(((XPObjectSpace)objectSpacePoupUp).Session, Categorie_Analyses);

            ObjectSpace.CommitChanges();
            objectSpacePoupUp.CommitChanges();
            DetailView dialogView = Application.CreateDetailView(objectSpacePoupUp, "Dossier_DetailView_Popup", true, DetailsPopup);
            e.DialogController.AcceptAction.Active.SetItemValue("Popup", false);
            e.View = dialogView;
        }

        

        //private Action Valider_param(DetailView dialogView, IObjectSpace objectSpacePoupUp)
        //{

        //    //Dossier dossier = (dialogView.CurrentObject as Dossier);
        //    //ListPropertyEditor listview_Parametre_Analyse_List = dialogView.FindItem(nameof(Dossier.Parametre_Analyse_List)) as ListPropertyEditor;
        //    //bool Ajouter;
        //    //foreach (Object itemLIst in listview_Parametre_Analyse_List.ListView.SelectedObjects)
        //    //{
        //    //    Ajouter = true;
        //    //    Parametre_Analyse Parametre_Analyse = (Parametre_Analyse)itemLIst;

        //    //    foreach (Dossier_Detail dossier_Detail1 in dossier.DossiDetails)
        //    //    {
        //    //        if (dossier_Detail1.NomAnalyse == Parametre_Analyse.Nom)
        //    //            Ajouter = false;
        //    //    }

        //    //    if (Ajouter == true)
        //    //    {
        //    //        Dossier_Detail dossier_Detail = objectSpacePoupUp.CreateObject<Dossier_Detail>();
        //    //        dossier_Detail.ParamAnalyse = Parametre_Analyse;
        //    //        dossier.DossiDetails.Add(dossier_Detail);
        //    //    }
        //    //    objectSpacePoupUp.CommitChanges();
        //    //}
        //    return null;
        //}

        private Control GetControl(Control _control, GridControl gridControl)
        {
            if (_control != null)
            {
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
            }


            return gridControl;
        }
        private void ValiderParam(object sender, SimpleActionExecuteEventArgs e)
        {
            Dossier dossier = (this.View.CurrentObject as Dossier);
            ListPropertyEditor listview_Parametre_Analyse_List = ((DetailView)View).FindItem(nameof(Dossier.Parametre_Analyse_List)) as ListPropertyEditor;
            bool Ajouter;
            foreach (Object itemLIst in listview_Parametre_Analyse_List.ListView.SelectedObjects)
            {
                Ajouter = true;
                Parametre_Analyse Parametre_Analyse = (Parametre_Analyse)itemLIst;

                foreach (Dossier_Detail dossier_Detail1 in dossier.DossiDetails)
                {
                    if (dossier_Detail1.NomAnalyse == Parametre_Analyse.Nom)
                        Ajouter = false;
                }

                if (Ajouter == true)
                {
                    Dossier_Detail dossier_Detail = ObjectSpace.CreateObject<Dossier_Detail>();
                    dossier_Detail.ParamAnalyse = Parametre_Analyse;
                    dossier.DossiDetails.Add(dossier_Detail);
                }
               
                ObjectSpace.CommitChanges();
                View.RefreshDataSource();
            }

            View.Close();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.

            if (View != null)
            {
                if (View.Id == "Dossier_DetailView_Popup")
                {
                    DetailView Dossier_View = View.ObjectSpace.Owner as DetailView;
                    Dossier dossier = Dossier_View.CurrentObject as Dossier;

                    foreach (Object Item in Dossier_View.Items)
                    {
                        Type type = Item.GetType();
                        if (type.Name == "ListPropertyEditor")
                        {
                            System.Windows.Forms.ListView listView = Item as System.Windows.Forms.ListView;
                        }
                    }

                    //ListView listView = Dossier_View.Items[1 as ListView;
                }


            }
            ListPropertyEditor listviewCategorie_Analyses = ((DetailView)View)?.FindItem(nameof(Dossier.Categorie_Analyses)) as ListPropertyEditor;

            if (listviewCategorie_Analyses != null)
            {
                Control control = listviewCategorie_Analyses.Control as Control;
                GridControl gridControl = GetControl(control, null) as GridControl;
                GridView gridView = (gridControl?.MainView as GridView);
                gridView?.UnselectRow(0);

            }

        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.

            base.OnDeactivated();
        }
    }
}
