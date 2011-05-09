using System;

namespace Mangifera.Messaging
{
    public interface ICommandBus
    {
        void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        void RegisterHandler<TCommand>(Action<TCommand> action);

        void PublishCommand<TCommand>() where TCommand : ICommand;
        void PublishCommand<TCommand>(TCommand command) where TCommand : ICommand;
    }
}