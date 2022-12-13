using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some_Bandits_Are_Now_Children.Settings
{
    internal interface ISettingVariables
    {
        int minPercentOfChildrenToAdd { get; set; } 
        int maxPercentOfChildrenToAdd { get; set; }
    }
}
