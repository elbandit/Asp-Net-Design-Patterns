using System;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Infrastructure.Email;
using Agathas.Storefront.Model.Orders.Events;

namespace Agathas.Storefront.Services.DomainEventHandlers
{
    public class OrderSubmittedHandler : IDomainEventHandler<OrderSubmittedEvent>
    {        
        public void Handle(OrderSubmittedEvent domainEvent)
        {
            StringBuilder emailBody = new StringBuilder();
            string emailAddress = domainEvent.Order.Customer.Email.Address;
            string emailSubject = String.Format("Agatha Order #{0}", domainEvent.Order.Id);

            emailBody.AppendLine(String.Format("Hello {0},", domainEvent.Order.Customer.Name.FirstName));
            emailBody.AppendLine();
            emailBody.AppendLine("The following order will be packed and dispatched as soon as possible.");
            emailBody.AppendLine(domainEvent.Order.ToString());
            emailBody.AppendLine();
            emailBody.AppendLine("Thank you for your custom.");
            emailBody.AppendLine("Agatha's");

            EmailServiceFactory.GetEmailService().SendMail("orders@Agatha.com",emailAddress, emailSubject, emailBody.ToString());
        }
    }
}
