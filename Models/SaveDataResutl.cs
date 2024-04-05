using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Storage;

namespace SampleApp.Models;
public record SaveDataResult
{
    public bool IsSuccesfull
    {
        get
        {
            if(Exception ==  null)
                return true;

            return false;
        }
    }
    public Exception? Exception
    {
        get;set;
    }

    public SaveDataResult(Exception? exception)
    {
        Exception = exception;
    }
    public SaveDataResult()
    {
    }
}
