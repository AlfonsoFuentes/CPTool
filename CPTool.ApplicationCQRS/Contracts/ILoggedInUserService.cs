using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Contracts
{
    public interface ILoggedInUserService
    {
        public string UserId { get; }
    }
}
