//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen_3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pasaporte
    {
        public int PasaporteId { get; set; }
        public string NumeroPasaporte { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public Nullable<System.DateTime> FechaExpiracion { get; set; }
        public int ViajeroId { get; set; }
    
        public virtual Viajero Viajero { get; set; }
    }
}
