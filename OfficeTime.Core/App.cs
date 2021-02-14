using MvvmCross;
using MvvmCross.ViewModels;
using OfficeTime.MvxStarter.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeTime.MvxStarter.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            
            RegisterAppStart<LoginViewModel>();
            //Mvx.IoCProvider.RegisterSingleton<IDialogService>(new DialogService());
        }
    }
}
