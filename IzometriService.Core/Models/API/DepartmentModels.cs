using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IzometriService.Core.Models.API
{
    public class BaseDepartmentModel
    {
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }

    public class DepartmentModel : BaseDepartmentModel
    {
        public int Id { get; set; }
    }

    public class DepartmentModelId : BaseDepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<DepartmentUserModel> Users { get; set; } = new List<DepartmentUserModel>();
    }


    public class DepartmentUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }


}
