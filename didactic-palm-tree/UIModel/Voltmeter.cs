using System;
using System.Windows;
using didactic_palm_tree.Simulation;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.ViewModels;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    internal class Voltmeter : Component
    {
        public Voltmeter(Diagram diagram)
        {
            this.SimComponent = new Simulation.Resistor(int.MaxValue, diagram.NetList);
        }

        public Voltmeter()
        {
        }
        public override ComponentViewModel CreateViewModel(Diagram diagram, DiagramViewModel parent)
        {
            return new VoltmeterViewModel(diagram, parent, Left, Top) {Model = this};
        }

        public override void EnsureSimComponentExists(Diagram diagram)
        {
            this.SimComponent = new Simulation.Resistor(int.MaxValue, diagram.NetList);
        }
    }
}