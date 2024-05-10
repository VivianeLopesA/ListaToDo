using System.ComponentModel.DataAnnotations;

namespace ListaToDo.Models
{
    public class Atividade
    {
        public int Id {  get; set; }

        [Display(Name = "Título")]
        [Required]
        public string? atividadeTitulo { get; set; }

        [Display(Name = "Descrição da Atividade")]
        public string? descricaoAtividade {  get; set; }

        [Display(Name = "Data da Criação")]
        //[DataType(DataType.Date)]
        public DateOnly dataAtividadeCriada { get; set; }

        [Display(Name = "Data Limite")]
        //[DataType(DataType.Date)]
        public DateOnly dataLimiteAtividade { get; set; }

        [Display(Name = "Categoria")]
        public string? categoriaAtividade { get; set; }

        public Atividade() { }


     
    }
}
