using System;
using System.Windows;
using didactic_palm_tree.Simulation;
using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    public class Wire
    {
        public Guid Id { get; set; }
        public Component Source { get; set; }
        public Component Sink { get; set; }
        public ConnectorOrientation SourceOrientation { get; set; }
        public ConnectorOrientation SinkOrientation { get; set; }
        public Diagram Diagram { get; set; }
        public ITerminal SinkTerminal { get; private set; }
        public ITerminal SourceTerminal { get; private set; }

        public Wire()
        {
            Id = Guid.NewGuid();
        }

        public void CreateTerminals()
        {
            SinkTerminal = new Terminal(Sink.SimComponent);
            SourceTerminal = new Terminal(Source.SimComponent);
        }
    }
}