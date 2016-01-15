

namespace didactic_palm_tree.Simulation
{
    public interface IComponent
    {
        double GetVoltageDrop();
        double GetCurrent();
        ITerminal Bottom { get; }
        ITerminal Top { get; }
        double GetResistance();
        bool IsVoltageSource();
        void Simulate();
    }
}