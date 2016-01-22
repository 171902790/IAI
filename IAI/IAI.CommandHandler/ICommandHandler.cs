using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAI.Commands;

namespace IAI.CommandHandler
{
    public interface ICommandHandler<in TCommand> where TCommand:ICommand
    {
        void Handle(TCommand command);
    }
}
