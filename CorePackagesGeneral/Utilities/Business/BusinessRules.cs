using CorePackagesGeneral.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackagesGeneral.Utilities.Business;

public class BusinessRules
{
    public static IResult Run(params IResult[] logics)
    {
        foreach (var logic in logics)
        {
            //Başarısız ise
            if (!logic.Success)
            {
                return logic; //ErrorResult
            }
        }
        return null;
    }
}
