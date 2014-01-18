using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace RPG
{
    public interface IZoneContent : INotifyPropertyChanged
    {
        AbstractZone Zone {get; set;}
    }
}
