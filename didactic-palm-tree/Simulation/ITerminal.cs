namespace didactic_palm_tree.Simulation
{
    public interface ITerminal
    {
        double Voltage { get; set; }
        IConnection GetConnection();
        IComponent GetComponent();
    }
}