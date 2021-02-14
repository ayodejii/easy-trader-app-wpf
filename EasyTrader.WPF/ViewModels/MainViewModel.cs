using EasyTrader.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
