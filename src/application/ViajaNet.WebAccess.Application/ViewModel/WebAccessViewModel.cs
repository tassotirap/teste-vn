namespace ViajaNet.WebAccess.Application.ViewModel
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class WebAccessViewModel
    {
        [Required(ErrorMessage = "The Url is Required")]
        [MinLength(5)]
        [MaxLength(255)]
        [DisplayName("Url")]
        public string Url { get; set; }

        [Required(ErrorMessage = "The Location is Required")]
        [MinLength(5)]
        [MaxLength(255)]
        public string Location { get; set; }

        [Required(ErrorMessage = "The IP is Required")]
        [MinLength(5)]
        [MaxLength(50)]
        public string IP { get; set; }

        [Required(ErrorMessage = "The Browser is Required")]
        [MinLength(1)]
        [MaxLength(50)]
        public string Browser { get; set; }
    }
}
