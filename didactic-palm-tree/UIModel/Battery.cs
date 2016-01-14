using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.ViewModels;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    [Table("Battery")]
    public class Battery  : Component
    {

        public Battery()
        {
            Voltage = Observable.Return("0");
            Current = Observable.Return("0");
        }

        public IObservable<string> Voltage { get; set; }
        public IObservable<string> Current { get; set; }

        public override ComponentViewModel CreateViewModel(DiagramViewModel parent)
        {
            return new BatteryViewModel(parent, Left, Top);
        }
    }
}
