namespace didactic_palm_tree.Simulation
{
    public interface IComponent
    {
        double GetVoltageDrop();
        ITerminal Bottom { get; set; }
    }
}