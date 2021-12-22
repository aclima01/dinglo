using Dinglo.Domain.Commands.Contracts;

namespace Dinglo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
