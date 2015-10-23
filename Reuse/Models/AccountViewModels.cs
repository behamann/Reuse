using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reuse.Models
{

public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(8, ErrorMessage = "Maximo de 8 caracteres")]
        [Display(Name = "CEP")]
        public string cep { get; set; }
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [StringLength(10, ErrorMessage = "Maximo de 10 caracteres")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(10, ErrorMessage = "Maximo de 10 caracteres")]
        [Display(Name = "Celular")]
        public string celular { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Lembrar esse navegador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A senha deve ser ao menos de 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(8, ErrorMessage = "Maximo de 8 caracteres")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        
        [StringLength(10, ErrorMessage = "Maximo de 10 caracteres")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(10, ErrorMessage = "Maximo de 10 caracteres")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A senha deve ser ao menos de 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
