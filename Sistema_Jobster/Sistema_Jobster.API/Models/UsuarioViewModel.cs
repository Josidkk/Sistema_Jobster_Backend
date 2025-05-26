using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Jobster.API.Models
{
    public class UsuarioViewModel
    {
        public int Usua_Id { get; set; }
        public string Usua_Nombre { get; set; }
        public string? Usua_Contrasena { get; set; }
        public string? Usua_Correo { get; set; }
        public bool Usua_EsAdmin { get; set; }
        public bool Usua_Publicador { get; set; }
        public string? Usua_Imagen { get; set; }
        public int Pers_Id { get; set; }

        public int Role_Id { get; set; }
        [NotMapped]
        public string Pers_Nombres { get; set; }
        [NotMapped]
        public string Pers_Apellidos { get; set; }
        [NotMapped]
        public string Role_Descripcion { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime Usua_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Usua_FechaModificacion { get; set; }
        public bool? Usua_Estado { get; set; }
    }
}