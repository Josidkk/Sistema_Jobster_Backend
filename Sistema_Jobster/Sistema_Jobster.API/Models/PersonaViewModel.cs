using System;

namespace Sistema_Jobster.API.Models
{
    public class PersonaViewModel
    {
        public int Pers_Id { get; set; }
        public string Pers_DNI { get; set; } = "";
        public string Pers_Nombres { get; set; } = "";
        public string Pers_Apellidos { get; set; } = "";
        public string Pers_Telefono { get; set; } = "";
        public string Pers_Sexo { get; set; } = "";
        public string Pers_Direccion { get; set; } = "";
        public string Pers_Curriculum { get; set; } = "";
        public int EsCi_Id { get; set; }
        public string EsCi_Descripcion { get; set; } = "";
        public string Muni_Codigo { get; set; } = "";
        public string Muni_Descripcion { get; set; } = "";
        public string Depa_Codigo { get; set; } = "";
        public string Depa_Descripcion { get; set; } = "";
        public bool Pers_Estado { get; set; }
        public int Usua_Creacion { get; set; }
        public string UsuaC_Nombre { get; set; } = "";
        public DateTime Pers_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public string UsuaM_Nombre { get; set; } = "";
        public DateTime? Pers_FechaModificacion { get; set; }
    }
}