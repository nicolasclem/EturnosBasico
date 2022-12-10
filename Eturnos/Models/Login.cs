using System.ComponentModel.DataAnnotations;

namespace Eturnos.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Required(ErrorMessage ="Debe ingresar un suario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar contraseña")]
        public string  Password { get; set; }
    }
}
