using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Core.Models.API.Base
{
    public class OrderSkipTakeReq : SkipTakeReq
    {
        public string? OrderBy { get; set; } = null;
    }
}
