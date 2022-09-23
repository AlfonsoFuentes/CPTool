using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPtool.ExtensionMethods
{
    [System.AttributeUsage(System.AttributeTargets.Property )]
    public class DerivedSaveAttribute : System.Attribute
    {
        public DerivedSaveAttribute()
        {
          
           
        }
    }
}
