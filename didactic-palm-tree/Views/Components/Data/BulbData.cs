using didactic_palm_tree.Views.Components.Abstract;

namespace didactic_palm_tree.Views.Components.Data
{
    class BulbData : ComponentData
    {
        public float Voltage { get; set; }

        public BulbData(float voltage)
        {
            Voltage = voltage;
        }
    }
}
