using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class Registerviewmodel
    {
        [Required]
        public string Username { get; set; }
        [Required]

        public string? Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
