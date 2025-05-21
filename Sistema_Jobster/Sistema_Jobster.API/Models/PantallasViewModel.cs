namespace Sistema_Jobster.API.Models
{
    public class PantallasViewModel
    {
        public int Pant_Id { get; set; }

        public string Pant_Nombre { get; set; }

        public string Pant_Ruta { get; set; }

        public string Pant_Controlador { get; set; }

        public string Pant_Esquema { get; set; }

        public int? Usua_Creacion { get; set; }

        public DateTime? Pant_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Pant_FechaModificacion { get; set; }
    }
}
