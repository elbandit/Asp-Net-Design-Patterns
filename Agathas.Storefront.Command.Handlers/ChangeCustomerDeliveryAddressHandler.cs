using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Commands;
using Agathas.Storefront.Infrastructure.CommandHandler;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model;
using Agathas.Storefront.Model.Customers;

namespace Agathas.Storefront.Command.Handlers
{
    public class ChangeCustomerDeliveryAddressHandler : ICommandHandler<DeliveryAddressModifyCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public ChangeCustomerDeliveryAddressHandler(ICustomerRepository customerRepository,
                                                    IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public void Execute(DeliveryAddressModifyCommand command)
        {
            
            Customer customer = _customerRepository.FindBy(command.CustomerIdentityToken);

            DeliveryAddress deliveryAddress =
                customer.DeliveryAddressBook.Where(d => d.Id == command.Address.Id).FirstOrDefault();

            if (deliveryAddress != null)
            {
                deliveryAddress.ChangeNameTo(command.Address.Name);

                var address = ConvertToAddressFrom(command.Address);

                deliveryAddress.ChangeAddressTo(address);

                _customerRepository.Save(customer);
                _uow.Commit();
            }            
        }

        private Address ConvertToAddressFrom(DeliveryAddressDto deliveryAddressSource)
        {
            var newAddress = new Address(deliveryAddressSource.AddressLine1,
                                         deliveryAddressSource.AddressLine2,
                                         deliveryAddressSource.City,
                                         deliveryAddressSource.State,
                                         deliveryAddressSource.Country,
                                         deliveryAddressSource.ZipCode);

            return newAddress;
        }
        
    }
}
