//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dalc
{
    using System;
    using System.Collections.Generic;
    
    public partial class alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public alumno()
        {
            this.malla = new HashSet<malla>();
        }
    
        public long id_alu { get; set; }
        public string codalu { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombres { get; set; }
        public string codcarr { get; set; }
    
        public virtual carrera carrera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<malla> malla { get; set; }
    }
}
