using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OfficeTime.Helpers
{
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
