using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xpert.Common.Base.Helper;

namespace Xpert.Common.Base.Persistent
{
    [NonPersistent]
    //[XafDefaultProperty("DisplayValueInLookup")]


    public class XpertBaseObject : BaseObject, ICloneable
    {
        public XpertBaseObject(Session session)
            : base(session)
        {
            //XPObject
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region
        [NonPersistentAttribute]
        bool HasCodification { get; set; } = false;

        public void setHasCodification(bool _hasCodification)
        {
            HasCodification = _hasCodification;
        }

        #endregion

        string codeUnite;
        DateTime modifiedOn;
        DateTime createdOn;
        string modifiedBy;
        string createdBy;



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Création par")]
        [VisibleInDetailView(false)]
        public string CreatedBy
        {
            get => createdBy;
            set => SetPropertyValue(nameof(CreatedBy), ref createdBy, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [VisibleInListView(false), VisibleInDetailView(false)]
        public string ModifiedBy
        {
            get => modifiedBy;
            set => SetPropertyValue(nameof(ModifiedBy), ref modifiedBy, value);
        }

        [ModelDefault("DisplayFormat", "{dd/MM/yyyy HH:mm:ss.SSS}")]
        [XafDisplayName("Date saisie")]
        [VisibleInDetailView(false)]
        public DateTime CreatedOn
        {
            get => createdOn;
            set => SetPropertyValue(nameof(CreatedOn), ref createdOn, value);
        }

        [ModelDefault("DisplayFormat", "{dd/MM/yyyy HH:mm:ss}")]
        [VisibleInDetailView(false)]
        public DateTime ModifiedOn
        {
            get => modifiedOn;
            set => SetPropertyValue(nameof(ModifiedOn), ref modifiedOn, value);
        }


        [VisibleInListView(false), VisibleInDetailView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodeUnite
        {
            get => codeUnite;
            set => SetPropertyValue(nameof(CodeUnite), ref codeUnite, value);
        }
        [VisibleInDashboards(false), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        public virtual string DisplayValueInLookup => "";

        public object XpertGetPropertyValue([CallerMemberName] string propertyName = null)
        {
            return this.GetPropertyValue(propertyName);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
        public string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> property)
        {
            MemberExpression memberExpression = (MemberExpression)property.Body;
            return memberExpression.Member.Name;
        }
        protected override void OnSaving()
        {
            if (Session.IsNewObject(this))
            {
                if (XpertHelper.IsNullOrEmpty(CreatedOn) || (XpertHelper.IsNotNullAndNotEmpty(CreatedOn) && CreatedOn.Equals(DateTime.MinValue)))
                {
                    CreatedOn = XpertHelper.GetDate();
                }
                CreatedBy = GetCurrentUser()?.UserName;
            }
            else
            {
                ModifiedOn = XpertHelper.GetDate();
                ModifiedBy = GetCurrentUser()?.UserName;
            }
            if (HasCodification)
            {
                string DisplayNamePersistent = GetDisplayNamePersistent();
                //if (XpertHelper.IsNotNullAndNotEmpty(DisplayNamePersistent))
                //{
                //    DisplayNamePersistent = this.GetType().Name;
                //    if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null)
                //                        && Session.IsNewObject(this)
                //                             && string.IsNullOrEmpty(numDemandeAchat))
                //    {

                //        int nextSequence = XpertGeneratorHelperID.Generate(Session, this.GetType().Name, "MyServerPrefix");
                //        numDemandeAchat = string.Format("D{0:D6}", nextSequence);
                //    }
                //}
            }
            base.OnSaving();
        }

        PermissionPolicyUser GetCurrentUser()
        {
            return Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);  // In XAF apps for versions older than v20.1.7.
            //return Session.FindObject<PermissionPolicyUser>(CriteriaOperator.Parse("Oid=CurrentUserId()"));  // In non-XAF apps where SecuritySystem.Instance is unavailable (v20.1.7+).
        }

        private string GetDisplayNamePersistent()
        {
            List<CustomAttributeData> listCustomAttributeData = this.GetType().CustomAttributes.ToList();
            if (XpertHelper.IsNotNullAndNotEmpty(listCustomAttributeData))
            {
                var res = listCustomAttributeData.Where(x => "XafDisplayNameAttribute".Equals(x.AttributeType.Name));
                if (XpertHelper.IsNotNullAndNotEmpty(res))
                {
                    CustomAttributeData XafDisplayName = res.FirstOrDefault();
                    if (XpertHelper.IsNotNullAndNotEmpty(XafDisplayName.ConstructorArguments) && XpertHelper.IsNotNullAndNotEmpty(XafDisplayName.ConstructorArguments[0]))
                    {
                        return Convert.ToString(XafDisplayName.ConstructorArguments[0].Value);
                    }
                }
            }
            return "";
        }
    }
}
