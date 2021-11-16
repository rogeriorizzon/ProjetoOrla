using System.ComponentModel.DataAnnotations;

namespace ProjetoOrla.Models
{
    public class Inicio
    {
        public int InicioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        public string Titulo_1 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Titulo_2 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string BotaoInicio { get; set; }

        public string FotoInicio { get; set; }
    }
}
