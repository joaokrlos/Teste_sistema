using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Cadastro_Sistema.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int FuncionarioId{ get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Genero { get; set; }

    }
}