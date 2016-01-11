namespace didactic_palm_tree.Simulation
{
    public interface ITerminal
    {
        int Voltage { get; set; }
        IConnection GetConnection();
        IComponent GetComponent();
    }
}