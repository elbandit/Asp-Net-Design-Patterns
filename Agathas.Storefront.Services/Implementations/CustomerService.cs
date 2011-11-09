using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Mapping;
using Agathas.Storefront.Services.Messaging.CustomerService;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public CustomerService(ICustomerRepository customerRepository,
                               IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }
                      
        public CreateCustomerResponse CreateCustomer(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new CreateCustomerResponse();
                        
            var email = new EmailAddress(request.Email);
            var name = new Name(request.FirstName, request.SecondName);

            var customer = new Customer(request.CustomerIdentityToken, email, name);

            ThrowExceptionIfCustomerIsInvalid(customer);

            _customerRepository.Add(customer);
            _uow.Commit();

            response.Customer = customer.ConvertToCustomerDetailView();

            return response;
        }

        private void ThrowExceptionIfCustomerIsInvalid(Customer customer)
        {
            if (customer.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("There were problems saving the Customer:");
                foreach (BusinessRule businessRule in customer.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }

                throw new CustomerInvalidException(brokenRules.ToString());

            }
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            GetCustomerResponse response = new GetCustomerResponse();

            Customer customer = _customerRepository.FindBy(request.CustomerIdentityToken);

            if (customer != null)
            {
                response.CustomerFound = true;
                response.Customer = customer.ConvertToCustomerDetailView();
                if (request.LoadOrderSummary)
                    response.Orders = customer.Orders.OrderByDescending(o => o.Created).ConvertToOrderSummaryViews();
            }
            else            
                response.CustomerFound = false;
            

            return response;
        }

        public ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request)
        {
            ModifyCustomerResponse response = new ModifyCustomerResponse();

            Customer customer = _customerRepository.FindBy(request.CustomerIdentityToken);

            var email = new EmailAddress(request.Email);
            var name = new Name(request.FirstName, request.SecondName);

            customer.ChangeEmailTo(email);
            customer.ChangeNameTo(name);
            
            ThrowExceptionIfCustomerIsInvalid(customer);

            _customerRepository.Save(customer);
            _uow.Commit();

            response.Customer = customer.ConvertToCustomerDetailView();

            return response;
        }

        public DeliveryAddressModifyResponse ModifyDeliveryAddress(DeliveryAddressModifyRequest request)
        {
            DeliveryAddressModifyResponse response = new DeliveryAddressModifyResponse();

            Customer customer = _customerRepository.FindBy(request.CustomerIdentityToken);

            DeliveryAddress deliveryAddress =
                customer.DeliveryAddressBook.Where(d => d.Id == request.Address.Id).FirstOrDefault();

            if (deliveryAddress != null)
            {
                var address = ConvertToAddress(request.Address);

                deliveryAddress.ChangeAddressTo(address);

                _customerRepository.Save(customer);
                _uow.Commit();
            }
                        
            response.DeliveryAddress = deliveryAddress.ConvertToDeliveryAddressView();

            return response;                        
        }
       
        public DeliveryAddressAddResponse AddDeliveryAddress(DeliveryAddressAddRequest request)
        {
            DeliveryAddressAddResponse response = new DeliveryAddressAddResponse();
            Customer customer = _customerRepository.FindBy(request.CustomerIdentityToken);

            Address address = ConvertToAddress(request.Address);
            
            customer.AddAddress(address, request.Address.Name);

            _customerRepository.Save(customer);
            _uow.Commit();

            //response.DeliveryAddress = deliveryAddress.ConvertToDeliveryAddressView();

            return response;
        }

        private Address ConvertToAddress(DeliveryAddressView deliveryAddressSource)
        {
            var newAddress = new Address(deliveryAddressSource.AddressAddressLine1,
                                         deliveryAddressSource.AddressAddressLine2,
                                         deliveryAddressSource.AddressCity,
                                         deliveryAddressSource.AddressState,
                                         deliveryAddressSource.AddressCountry,
                                         deliveryAddressSource.AddressZipCode);


            return newAddress;
        }
    }
}
    