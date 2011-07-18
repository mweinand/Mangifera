using System.Windows;

namespace Mangifera.Phone.UI
{
    public class DialogService : IDialogService
    {

        public bool Confirm(string message)
        {
            var result = MessageBox.Show(message, "Confirm", MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK;
        }

        public void Alert(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButton.OK);            
        }
    }
}