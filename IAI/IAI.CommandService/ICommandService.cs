using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Excute<TCommand>(TCommand command) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }
    }
}
