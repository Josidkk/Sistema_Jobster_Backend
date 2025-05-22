namespace Sistema_Jobster.API.Models
{
    public class RequisitoViewModel
    {
        public int Requ_Id { get; set; }

        public string Requ_Descripcion { get; set; }

        public string Requ_Informacion { get; set; }

        public bool? Requ_Estado { get; set; }

        public int Usua_Creacion { get; set; }
        public int? Plaz_Id { get; set; }

        public DateTime Requ_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Requ_FechaModificacion { get; set; }
    }
}
