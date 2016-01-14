﻿using didactic_palm_tree.Views.Components.Abstract;

namespace didactic_palm_tree.Views.Components.Data
{
    class BatteryData : ComponentData
    {
        public float Voltage { get; set; }

        public string Setting { get; set; }

        public BatteryData(string setting)
        {
            this.Setting = setting;
        }
    }
}
