namespace didactic_palm_tree.Simulation
{
    internal class Terminal : ITerminal
    {
        private IComponent _component;

        public Terminal(IComponent component)
        {
            _component = component;
        }

        public double Voltage { get; set; }
        public IConnection Connection { get; set; }

        public IComponent GetComponent()
        {
            return _component;
        }
    }
}