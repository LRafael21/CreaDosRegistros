using System.ComponentModel.DataAnnotations;

namespace RegistroCarreras.Entidades
{
    public class Carreras
    {
        [Key]
        public int CarrerasId { get; set; }
        public string  Nombre { get; set; }  

    }

}