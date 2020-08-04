using System;
using System.ComponentModel.DataAnnotations;
namespace cursosNetCore.Models
{
    public class Category
    {

        #region Properties
        public int CategoryID { get; set; }

        [Required (ErrorMessage ="El campo es requerido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre de debe tener de 4 a 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "La descripción no debe exceder los 255 caracteres")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Estado")]
        public Boolean Status { get; set; }
        #endregion  
    }
}
