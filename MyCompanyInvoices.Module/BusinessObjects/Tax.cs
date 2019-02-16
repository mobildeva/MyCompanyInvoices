using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace MyCompanyInvoices.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Tax : XPObject
    {
        public Tax() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Tax(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        double numericValue;
        public double NumericValue
        {
            get
            {
                return numericValue;
            }
            set { SetPropertyValue(nameof(NumericValue), ref numericValue, value); }
        }

        TaxType type;

        public TaxType Type
        {
            get
            {
                return type;
            }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }

        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        [Association("Invoice-Taxes")]
        public XPCollection<Invoice> Invoices
        {
            get
            {
                return GetCollection<Invoice>(nameof(Invoices));
            }
        }
    }
    public enum TaxType
    {
        percentual = 1,
        global = 2,
        percentualByItem = 3
    }
}