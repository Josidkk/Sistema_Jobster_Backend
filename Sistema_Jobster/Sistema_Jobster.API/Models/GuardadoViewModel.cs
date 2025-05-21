namespace Sistema_Jobster.API.Models
{
    public class GuardadoViewModel
    {
        public int Guar_Id { get; set; }

        public int Plaz_Id { get; set; }

        public int Usua_Id { get; set; }

        public bool? Guar_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Guar_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Guar_FechaModificacion { get; set; }
    }
}
