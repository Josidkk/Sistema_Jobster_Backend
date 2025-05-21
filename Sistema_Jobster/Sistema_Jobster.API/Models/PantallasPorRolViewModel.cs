using System;

namespace Sistema_Jobster.API.Models
{
    public class PantallasPorRolViewModel
    {
        public int PaRo_Id { get; set; }
        public int? Role_Id { get; set; }
        public int? Pant_Id { get; set; }
        public int? Usua_Creacion { get; set; }
        public DateTime? PaRo_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? PaRo_FechaModificacion { get; set; }
    }
}