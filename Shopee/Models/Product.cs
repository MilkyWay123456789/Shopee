//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopee.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductOfMembers = new HashSet<ProductOfMember>();
            this.Purchases = new HashSet<Purchase>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> OldPrice { get; set; }
        public Nullable<int> NewPrice { get; set; }
        public Nullable<int> Sale { get; set; }
        public string Travel { get; set; }
        public Nullable<int> Counts { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public string Review { get; set; }
        public Nullable<int> Bought { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Picture { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOfMember> ProductOfMembers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
