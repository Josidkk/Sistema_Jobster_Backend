namespace Sistema_Jobster.API.Models
{
    public class SolicitudViewModel
    {

        public int Soli_Id { get; set; }

        public string Soli_Comentario { get; set; }

        public string Soli_Revision { get; set; }

        public int Plaz_Id { get; set; }

        public int Usua_Id { get; set; }

        public bool? Soli_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Soli_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Soli_FechaModificacion { get; set; }
    }
}
