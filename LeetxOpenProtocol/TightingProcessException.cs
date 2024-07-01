using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetx.OpenProtocol
{
    public class TightingProcessException : Exception
    {
       public TightingProcessException( string message) : base(message){ 
        
        }

    }
}
