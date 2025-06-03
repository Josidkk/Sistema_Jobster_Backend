using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Jobster.API.Models
{
    public class PlazaViewModel
    {
        public int Plaz_Id { get; set; }

        public string Plaz_Descripcion { get; set; }

        public string Plaz_Informacion { get; set; }

        public string Plaz_Direccion { get; set; }

        public string Plaz_Telefono { get; set; }

        public string Plaz_Correo { get; set; }

        public string Plaz_Imagen { get; set; }

        public string Muni_Codigo { get; set; }

        public int Cate_Id { get; set; }

        public int Usua_Id { get; set; }

        public int Carg_Id { get; set; }

        public int TiCo_Id { get; set; }

        public bool? Plaz_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Plaz_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Plaz_FechaModificacion { get; set; }




        [NotMapped]
        public string Muni_Descripcion { get; set; }
        [NotMapped]
        public string Depa_Descripcion { get; set; }
        [NotMapped]
        public string Cate_Descripcion { get; set; }
        [NotMapped]
        public string Usua_Nombre { get; set; }
        [NotMapped]
        public string Usua_Correo { get; set; }
        [NotMapped]
        public string Usua_Imagen { get; set; }
        [NotMapped]
        public string Pers_Telefono { get; set; }
        [NotMapped]
        public string Pers_Nombres { get; set; }
        [NotMapped]
        public string Pers_Apellidos { get; set; }
        [NotMapped]
        public string Carg_Descripcion { get; set; }
        [NotMapped]
        public string TiCo_Descripcion { get; set; }
    }
}
