using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo_Ejercicio_Lab4.Data.Entities
{
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Todo_Item { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false; //borrado lógico
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        public int CreatorId { get; set; }
    }
}
