using System.ComponentModel.DataAnnotations;

namespace ImpulsoTeste.Marcilio.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}