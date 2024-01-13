namespace IntuitChallenge.Models;

public class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime Fecha_Nacimiento { get; set; }

    public string Cuit { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string Telefono_Celular { get; set; } = null!;

    public string Email { get; set; } = null!;
}
