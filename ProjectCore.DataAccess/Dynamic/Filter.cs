using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.DataAccess.Dynamic;

public class Filter
{
    public string Field { get; set; } // where
    public string? Value { get; set; }
    public string Operator { get; set; } // eşittir
    public string? Logic { get; set; } // and or
    public IEnumerable<Filter> Filters { get; set; }
    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }
    public Filter(string field, string @operator)
    {
        Field = field;
        Operator = @operator;
    }
}
