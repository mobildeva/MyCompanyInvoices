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

namespace MyCompanyInvoices.Module.BusinessObjects
{
    [NonPersistent]
    public abstract class MainBasePerson : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public MainBasePerson(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.UserAddress = new Address(this.Session);
        }

        Address userAddress;
        string id;
        string lastName;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Id
        {
            get { return id; }
            set { SetPropertyValue(nameof(Id), ref id, value); }
        }
        [DevExpress.Xpo.Aggregated]
        public Address UserAddress
        {
            get
            {
                return userAddress;
            }
            set { SetPropertyValue(nameof(UserAddress), ref userAddress, value); }
        }
    }
}