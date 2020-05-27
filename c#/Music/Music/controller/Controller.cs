using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.controller
{
    class Controller
    {
        private CommandProvider commandProvider = CommandProvider.GetInstance();
        public object complete(string request , object data)
        {
            ICommand command = commandProvider.GetCommand(request);
            return command.Execute(data);
        }
    }
}
