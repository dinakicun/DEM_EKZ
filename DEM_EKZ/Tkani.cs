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
    
    public partial class Tkani
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tkani()
        {
            this.SkladTkani = new HashSet<SkladTkani>();
            this.TkaniIzdeliya = new HashSet<TkaniIzdeliya>();
            this.Cvet = new HashSet<Cvet>();
            this.Risunok = new HashSet<Risunok>();
            this.Sostav = new HashSet<Sostav>();
        }
    
        public string Articul { get; set; }
        public string Nazvanie { get; set; }
        public double Shirina { get; set; }
        public double Dlina { get; set; }
        public decimal Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkladTkani> SkladTkani { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TkaniIzdeliya> TkaniIzdeliya { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cvet> Cvet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Risunok> Risunok { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sostav> Sostav { get; set; }
    }
}
