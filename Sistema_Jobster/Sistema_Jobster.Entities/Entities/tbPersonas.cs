using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Jobster.Entities.Entities
{
    public class tbPersonas
    {
        public int Pers_Id { get; set; }
        public string Pers_DNI { get; set; }
        public string Pers_Nombres { get; set; }
        public string Pers_Apellidos { get; set; }
        public string Pers_Telefono { get; set; }
        public string Pers_Sexo { get; set; }
        public string Pers_Direccion { get; set; }
        public string Pers_Curriculum { get; set; }
        public int EsCi_Id { get; set; }
        public string Muni_Codigo { get; set; }
        public bool Pers_Estado { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime Pers_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Pers_FechaModificacion { get; set; }
        
        // Campos adicionales con NotMapped
        [NotMapped]
        public string Depa_Codigo { get; set; }
        
        [NotMapped]
        public string UsuaC_Nombre { get; set; }
        
        [NotMapped]
        public string UsuaM_Nombre { get; set; }
        
        [NotMapped]
        public string Depa_Descripcion { get; set; }
        
        [NotMapped]
        public string EsCi_Descripcion { get; set; }
        
        [NotMapped]
        public string Muni_Descripcion { get; set; }
    }
}