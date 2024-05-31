using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Core.Models.API.Base
{
    public class SkipTakeReq
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
