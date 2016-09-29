using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace NuGetGallery.Authentication.Providers.ActiveDirectory
{
    public static class ActiveDirectoryLoginProvider
    {
        public static bool ValidateCredentials(string domain, string userName, string password, out string Name)
        {
            using (var context = new PrincipalContext(ContextType.Domain, domain))
            {
                bool isValid = context.ValidateCredentials(userName, password);
                Name = "";

                if (isValid)
                {
                    using (var user = UserPrincipal.FindByIdentity(context, userName))
                    {
                        Name = user.Name;
                    }
                }

                return isValid;
            }
        }
    }
}