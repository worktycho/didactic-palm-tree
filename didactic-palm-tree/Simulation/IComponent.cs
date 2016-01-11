namespace didactic_palm_tree.Simulation
{
    public interface IComponent
    {
        int GetVoltageDrop();
        ITerminal Bottom { get; set; }
    }
}