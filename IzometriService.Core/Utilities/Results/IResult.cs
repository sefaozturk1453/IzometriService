using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Core.Utilities.Results
{
    public interface IResult : IResult<string>
    {

    }

    public interface IResult<T>
    {
        T Data { get; set; }
        bool IsSuccess { get; }
        string Message { get; }
    }
}
