//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEM_EKZ
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zakaz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zakaz()
        {
            this.ZakazniyeIzdeliya = new HashSet<ZakazniyeIzdeliya>();
        }
    
        public int Nomer { get; set; }
        public System.DateTime DATA { get; set; }
        public string STATUS { get; set; }
        public Nullable<int> IdZakazchika { get; set; }
        public Nullable<int> IdManagera { get; set; }
        public decimal Stoimost { get; set; }
    
        public virtual AppUser AppUser { get; set; }
        public virtual AppUser AppUser1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZakazniyeIzdeliya> ZakazniyeIzdeliya { get; set; }
    }
}
