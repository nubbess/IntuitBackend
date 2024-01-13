using System.ComponentModel.DataAnnotations;
using ToolsLibrary;

namespace IntuitChallenge.Models.DTO
{
    public class ClienteCreateDto
    {
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        [StringLength(11)]
        public string Cuit { get; set; }
        [Required]
        [StringLength(50)]
        public string Domicilio { get; set; }
        [Required]
        [StringLength(20)]
        public string Telefono_Celular { get; set; }
        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
