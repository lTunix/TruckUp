//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TruckUp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMUNA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMUNA()
        {
            this.CENTRAL = new HashSet<CENTRAL>();
        }
    
        public int ID_COMUNA { get; set; }
        public int ID_PROVINCIA { get; set; }
        public string NOMBRE_COMUNA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CENTRAL> CENTRAL { get; set; }
        public virtual PROVINCIA PROVINCIA { get; set; }
    }
}
