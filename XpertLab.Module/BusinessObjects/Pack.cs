using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xpert.Common.Base.Persistent;

namespace XpertLab.Module.BusinessObjects
{
    [XafDefaultProperty("NomPack")]
    public class Pack : XPBaseObject
    {
        private string codePack;
        private string nomPack;

        public Pack(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Persistent("CodePack"), Key(true)]
        [VisibleInDetailView(false), VisibleInListView(false)]
        public string CodePack
        {
            get { return codePack; }
            set { SetPropertyValue(nameof(CodePack), ref codePack, value); }
        }

        [XafDisplayName("Nom Pack")]
        public string NomPack
        {
            get { return nomPack; }
            set { SetPropertyValue(nameof(NomPack), ref nomPack, value); }
        }
    }
}