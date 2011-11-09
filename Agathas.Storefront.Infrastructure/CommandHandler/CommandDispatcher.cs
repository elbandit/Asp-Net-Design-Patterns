using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Container;

namespace Agathas.Storefront.Infrastructure.CommandHandler
{
    public class CommandDispatcher
    {
        private readonly IContainer _container;

        public CommandDispatcher(IContainer container)
        {
            _container = container;
        }

        public void Handle<T>(T command) where T: ICommand
        {
            var handlers = _container.ResolveAll<ICommandHandler<T>>();

            foreach (var handler in handlers)
                handler.Execute(command);
        }
    }    
}
