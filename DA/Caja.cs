//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Caja
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Estado { get; set; }
    
        public virtual Alumno Alumno { get; set; }
    }
}