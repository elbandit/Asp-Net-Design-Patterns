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
    public class AddCustomerDeliveryAddressCommandHandler: ICommandHandler<AddCustomerDeliveryAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public AddCustomerDeliveryAddressCommandHandler(ICustomerRepository customerRepository,
                                                        IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public void Execute(AddCustomerDeliveryAddressCommand command)
        {            
            //Customer customer = _customerRepository.FindBy(command.CustomerIdentityToken);

            //var deliveryAddress = new DeliveryAddress();

            //deliveryAddress.Customer = customer;
            
            ////UpdateDeliveryAddressFrom(request.Address, deliveryAddress);

            //customer.AddAddress(deliveryAddress);

            //_customerRepository.Save(customer);
            //_uow.Commit();
        }
    }    
}
