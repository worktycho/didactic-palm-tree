﻿using System.Windows;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.ViewModels;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    internal class Bulb : Component
    {

        public override ComponentViewModel CreateViewModel(Diagram diagram, DiagramViewModel parent)
        {
            return new BulbViewModel(parent, Left, Top) {Model = this};
        }

        public override void EnsureSimComponentExists(Diagram diagram)
        {
            
        }
    }
}