using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMngSys.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string NewPhotoFile { get; set; }
    }
}
