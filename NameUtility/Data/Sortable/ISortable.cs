using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameUtility.Data
{
    public interface ISortable
    {
        string Value { get; set; }
        string GetValueAsSorted();
    }
}
