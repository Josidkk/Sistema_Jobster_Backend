namespace Sistema_Jobster.API.Models
{
    public class RolesViewModel
    {
        public int Role_Id { get; set; }

        public string Role_Descripcion { get; set; }
        public bool Role_Estado { get; set; }
        public DateTime? Role_FechaCreacion { get; set; }
        public DateTime? Role_FechaModificacion { get; set; }
        public int? Usua_Creacion { get; set; }
        public int? Usua_Modificacion { get; set; }

    }
}
