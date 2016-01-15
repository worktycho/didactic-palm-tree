﻿using didactic_palm_tree.Views.Components.Abstract;

namespace didactic_palm_tree.Views.Components.Data
{
    class BatteryData : ComponentData
    {
        public float Voltage { get; set; }

        public BatteryData(float voltage)
        {
            this.Voltage = voltage;
        }
    }
}
