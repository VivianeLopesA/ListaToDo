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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]

        public DateOnly dataAtividadeCriada { get; set; }

        [Display(Name = "Data Limite")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public DateOnly dataLimiteAtividade { get; set; }

        [Display(Name = "Categoria")]
        public string? categoriaAtividade { get; set; }

        public Atividade() { }


     
    }
}
