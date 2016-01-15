using didactic_palm_tree.Views.Components.Abstract;

namespace didactic_palm_tree.Views.Components.Data
{
    class SwitchData : ComponentData
    {
        public bool IsOn { get; set; }

        public SwitchData(bool isOn)
        {
            IsOn = isOn;
        }
    }
}
