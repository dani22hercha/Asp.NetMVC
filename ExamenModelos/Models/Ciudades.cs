//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenModelos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciudades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ciudades()
        {
            this.Unidad_recidencial = new HashSet<Unidad_recidencial>();
        }
    
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdDepartamentos { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unidad_recidencial> Unidad_recidencial { get; set; }
    }
}
