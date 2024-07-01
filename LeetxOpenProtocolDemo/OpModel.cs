using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetxOpenProtocolDemo
{
    internal class OpModel : Leetx.OpenProtocol.PropertyChangedEvent
    {
        public List<int> PsetList { get; set;{ RaisePropertyChanged()} }

    }
}
