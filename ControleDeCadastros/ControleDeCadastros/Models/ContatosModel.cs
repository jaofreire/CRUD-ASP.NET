using System.ComponentModel.DataAnnotations;

namespace ControleDeCadastros.Models
{
    public class ContatosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "Email inválido!!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "Celular inválido!!")]
        public string? Celular { get; set; }

    }
}
