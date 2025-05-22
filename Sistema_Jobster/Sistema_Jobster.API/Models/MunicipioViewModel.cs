namespace Sistema_Jobster.API.Models
{
    public class MunicipioViewModel
    {
        public string Muni_Codigo { get; set; }

        public string Muni_Descripcion { get; set; }

        public string Depa_Codigo { get; set; }

        public DateTime? Muni_FechaCreacion { get; set; }

        public DateTime? Muni_FechaModificacion { get; set; }

        public int? Usua_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }
    }
}
