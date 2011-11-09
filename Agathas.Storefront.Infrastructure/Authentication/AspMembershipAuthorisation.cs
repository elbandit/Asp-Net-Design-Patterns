using System;
using System.Web.Security;

namespace Agathas.Storefront.Infrastructure.Authentication
{
    public class AspMembershipAuthorisation : ILocalAuthenticationService 
    {  
        public User Login(string email, string password)
        {
            User user = new User();
            user.IsAuthenticated = false;

            if (Membership.ValidateUser(email, password))
            {
                MembershipUser validatedUser = Membership.GetUser(email);
                user.AuthenticationToken = validatedUser.ProviderUserKey.ToString();
                user.Email = email;
                user.IsAuthenticated = true;
            }

            return user;
        }

        public User RegisterUser(string email, string password)
        {            
            MembershipCreateStatus status;
            User user = new User();
            user.IsAuthenticated = false;

            Membership.CreateUser(email, password, email, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, out status);

            if (status == MembershipCreateStatus.Success)
            {
                MembershipUser newlyCreatedUser = Membership.GetUser(email);
                user.AuthenticationToken = newlyCreatedUser.ProviderUserKey.ToString();
                user.Email = email;
                user.IsAuthenticated = true;
            }
            else
            {
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        throw new InvalidOperationException("There is already a user with this email address.");                    
                    case MembershipCreateStatus.DuplicateUserName:
                        throw new InvalidOperationException("There is already a user with this email address.");                    
                    case MembershipCreateStatus.InvalidEmail:
                        throw new InvalidOperationException("Your email address is invalid");
                    case MembershipCreateStatus.InvalidPassword:
                        throw new InvalidOperationException("Your password is invalid.");                                                  
                    default:
                        throw new InvalidOperationException("There was a problem creating your account. Please try again.");
                }
            }

            return user;
        }       
    }
}
