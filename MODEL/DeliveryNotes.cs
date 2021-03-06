//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryNotes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryNotes()
        {
            this.Debts = new HashSet<Debts>();
            this.DeliveryDetails = new HashSet<DeliveryDetails>();
        }
    
        public int DeliveryNoteID { get; set; }
        public System.DateTime deliverDateCreated { get; set; }
        public string receiverName { get; set; }
        public string deliverName { get; set; }
        public int AgencyID { get; set; }
        public decimal totalPrice { get; set; }
        public decimal debt { get; set; }
        public Nullable<System.DateTime> endeliverdate { get; set; }
        public Nullable<decimal> thanhtoan { get; set; }
    
        public virtual Agencies Agencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Debts> Debts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryDetails> DeliveryDetails { get; set; }
    }
}
