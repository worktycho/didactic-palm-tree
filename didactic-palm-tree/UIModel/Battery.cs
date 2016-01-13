using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Reactive;
using System.Reactive.Linq;

namespace didactic_palm_tree.UIModel
{
    public class Battery
    {
        public Battery()
        {
            Voltage = Observable.Return("0");
            Current = Observable.Return("0");
        }

        public IObservable<string> Voltage { get; set; }
        public IObservable<string> Current { get; set; }
    }
}
