namespace Mangifera.Phone.UI
{
    public interface IDialogService
    {
        bool Confirm(string message);
        void Alert(string message);
    }
}
