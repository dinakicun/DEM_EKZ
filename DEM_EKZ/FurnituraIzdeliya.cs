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
    
    public partial class FurnituraIzdeliya
    {
        public int Id { get; set; }
        public string IdFurnitura { get; set; }
        public string IdIzdeliya { get; set; }
        public string Razmeshchenie { get; set; }
        public int Kolichestvo { get; set; }
        public string Povorot { get; set; }
    
        public virtual Furnitura Furnitura { get; set; }
        public virtual Izdeliya Izdeliya { get; set; }
    }
}
