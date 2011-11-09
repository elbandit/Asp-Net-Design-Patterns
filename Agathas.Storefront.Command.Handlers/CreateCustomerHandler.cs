using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Commands;
using Agathas.Storefront.Infrastructure.CommandHandler;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Customers;

namespace Agathas.Storefront.Command.Handlers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public CreateCustomerHandler(ICustomerRepository customerRepository,
                                     IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public void Execute(CreateCustomerCommand command)
        {                        
            var email = new EmailAddress(command.Email);
            var name = new Name(command.FirstName, command.SecondName);

            var customer = new Customer(command.CustomerIdentityToken, email, name);
            
            _customerRepository.Add(customer);
            _uow.Commit();            
        }
    }
}
