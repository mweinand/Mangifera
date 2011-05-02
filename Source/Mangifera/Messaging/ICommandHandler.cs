namespace Mangifera.Messaging
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}