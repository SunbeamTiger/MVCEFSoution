using DBProject.Models;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MVCAppWithEF.ViewModels
{
    public class EditCustomerViewModel
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Firstname Required")]
        [StringLength(40)]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
