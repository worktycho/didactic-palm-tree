namespace didactic_palm_tree.Simulation
{
    public interface ITerminal
    {
        double Voltage { get; set; }
        IConnection Connection { get; set; }
        IComponent GetComponent();
    }
}