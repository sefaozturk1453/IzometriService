using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IzometriService.Core.Models.API
{
    public class BaseUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentId { get; set; }
    }
    public class UserModel : BaseUserModel
    {
        public int Id { get; set; }
        public string? Department { get; set; }

    }


   
   
}
