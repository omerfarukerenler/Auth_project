using System.ComponentModel.DataAnnotations;

namespace Auth_project.Models
{
    public class Register
    {
        [Required(ErrorMessage = "İsim zorunlu bir alan.")]
        [MinLength(3, ErrorMessage = "İsminiz en az 3 karakter olmalıdır")]
        public string FirstName { get; set; }




        [Required(ErrorMessage = "Soyisim zorunlu bir alan.")]
        [MinLength(3, ErrorMessage = "Soyisminiz en az 3 karakter olmalıdır")]
        public string LastName { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun email adresi giriniz")]
        [Required(ErrorMessage = "Email zorunlu bir alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu bir alan.")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu bir alan.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı zorunlu bir alan.")]
        [MinLength(3, ErrorMessage = "İsminiz en az 3 karakter olmalıdır")]
        public string UserName { get; set; }
    }
}
