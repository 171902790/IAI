using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using IAI.CommandHandler;
using IAI.Commands;

namespace IAI.CommandService
{
    public interface ICommandService
    {
        void Excute<TCommand>(TCommand command) where TCommand:ICommand;
    }

    public class CommandSercie:ICommandService
    {
        private readonly IWindsorContainer _container;

        public CommandSercie(IWindsorContainer container)
        {
            _container = container;
        }

        public void Excute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _container.Resolve<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }
    }
}
