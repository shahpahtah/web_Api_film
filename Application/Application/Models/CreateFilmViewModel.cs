using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CreateFilmViewModel
    {
        [Required(ErrorMessage = "Название обязательно.")]
        [StringLength(200, ErrorMessage = "Название не может превышать 200 символов.")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(1888, 2100, ErrorMessage = "Год должен быть между 1888 и 2100.")]
        public int Year { get; set; }

        [StringLength(200, ErrorMessage = "Режиссер не может превышать 200 символов.")]
        public string Director { get; set; }

        public IFormFile Poster { get; set; }

    }
}
