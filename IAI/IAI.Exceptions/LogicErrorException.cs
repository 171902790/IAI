using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAI.Exceptions
{
    public abstract class LogicErrorException:Exception
    {
        public abstract string ErrorMessage { get;  }
    }

    public class PasswordErrorException : LogicErrorException
    {
        public override string ErrorMessage
        {
            get { return "密码错误"; }
        }
    }
}
