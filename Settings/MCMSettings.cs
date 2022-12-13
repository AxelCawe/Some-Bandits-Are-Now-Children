using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Abstractions.FluentBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some_Bandits_Are_Now_Children.Settings
{
    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingVariables
    {
        public override string Id => "Some_Bandits_Are_Now_Children";

        public override string DisplayName => "Some Bandits Are Now Children";

        public override string FolderName => "Some_Bandits_Are_Now_Children";

        public override string FormatType => "xml";


        [SettingPropertyInteger("{=settings_MinPercent}Minimum Percent Of Children To Add", GlobalModSettings.minMinChildrenToAdd, GlobalModSettings.maxMinChildrenToAdd, Order = 0,HintText = "{=settings_MinPercentDesc}If I have 10 looters, setting it to 50% will result with at least 5 looter children.", RequireRestart = false)]
        public int minPercentOfChildrenToAdd { get; set; } = 20;
        [SettingPropertyInteger("{=settings_MaxPercent}Maximum Percent Of Children To Add", GlobalModSettings.minMaxChildrenToAdd, GlobalModSettings.maxMaxChildrenToAdd, Order = 1, HintText = "{=settings_MaxPercentDesc}If I have 10 looters, setting it to 50% will result with at most 5 looter children.", RequireRestart = false)]
        public int maxPercentOfChildrenToAdd { get; set; } = 20;
    }
}
