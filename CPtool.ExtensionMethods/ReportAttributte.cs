using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPtool.ExtensionMethods
{
    public class ReportAttribute : Attribute
    {
       public int Order { get; set; }
    }
    public class ObjectReportAttribute : Attribute
    {
       
    }
}
