using System;
using System.Windows;
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

        public Wire()
        {
            Id = Guid.NewGuid();
        }
    }
}