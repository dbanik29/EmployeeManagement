using System.ComponentModel.DataAnnotations;

namespace EmployeeMngSys.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
