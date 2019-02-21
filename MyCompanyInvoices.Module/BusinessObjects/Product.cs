using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace MyCompanyInvoices.Module.BusinessObjects
{   [NavigationItem("Business Area")]
    [DefaultClassOptions]
    [DefaultProperty("Name")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Product : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

        
        public Product(Session session)
            : base(session)
        {
            
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //IObjectSpace objectSpace;

            //var instance = SingletonSettings.GetInstance(objectSpace);
            
            //var userId = SecuritySystem.CurrentUserId;
           //SubsidiaryId = new Subsidiary(Session).Oid.ToString();
           
           //var user= Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId) as CompanySeller;
           // if (user != null) {
           //     SubsidiaryId = user.Subsidiary.Oid;
           //     IsGlobal = false;
            //}           

            
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        bool isGlobal;
        Guid subsidiaryId;
        Category category;
        Subsidiary subsidiary;
        string tradeMark;
        double price;
        string name;
        
        public bool IsGlobal
        {
            get
            {
                return isGlobal;
            }
            set
            {
                SetPropertyValue(nameof(IsGlobal), ref isGlobal, value);
            }
        }

       [Browsable(false)]
        public Guid SubsidiaryId
        {
            get
            {
                return subsidiaryId;
            }
            set
            {
                SetPropertyValue(nameof(SubsidiaryId), ref subsidiaryId, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetPropertyValue(nameof(Name), ref name, value);
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                SetPropertyValue(nameof(Price), ref price, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TradeMark
        {
            get
            {
                return tradeMark;
            }
            set
            {
                SetPropertyValue(nameof(TradeMark), ref tradeMark, value);
            }
        }
        [Association("Subsidiary-Products")]
        public Subsidiary Subsidiary
        {
            get
            {
                return subsidiary;
            }
            set
            {
                SetPropertyValue(nameof(Subsidiary), ref subsidiary, value);
            }
        }
        [Association("Invoice-Products")]
        public XPCollection<Invoice> Invoices
        {
            get
            {
                return GetCollection<Invoice>(nameof(Invoices));
            }
        }
        [Association("Category-Product")]
        public Category Category
        {
            get { return category; }
            set { SetPropertyValue(nameof(Category), ref category, value); }
        }

    }
}