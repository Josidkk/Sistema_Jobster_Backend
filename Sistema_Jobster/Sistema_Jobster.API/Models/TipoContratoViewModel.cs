namespace Sistema_Jobster.API.Models
{
    public class TipoContratoViewModel
    {
        public int TiCo_Id { get; set; }

        public string TiCo_Descripcion { get; set; }

        public bool? TiCo_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime TiCo_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? TiCo_FechaModificacion { get; set; }
    }
}
