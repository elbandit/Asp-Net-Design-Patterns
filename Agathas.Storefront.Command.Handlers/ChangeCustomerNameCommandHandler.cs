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
    public class ChangeCustomerNameCommandHandler : ICommandHandler<ChangeCustomerNameCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public ChangeCustomerNameCommandHandler(ICustomerRepository customerRepository,
                                                IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;            
        }

        public void Execute(ChangeCustomerNameCommand command)
        {
            Customer customer = _customerRepository.FindBy(command.CustomerIdentityToken);

            var newCustomerName = new Name(command.FirstName, command.LastName);

            customer.ChangeNameTo(newCustomerName);
            
            _customerRepository.Save(customer);
            _uow.Commit();            
        }
    }
}
