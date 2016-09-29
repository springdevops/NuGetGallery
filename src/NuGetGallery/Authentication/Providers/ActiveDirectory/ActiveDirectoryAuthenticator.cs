// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using NuGetGallery.Configuration;
using Owin;

namespace NuGetGallery.Authentication.Providers.ActiveDirectory
{
    public class ActiveDirectoryAuthenticator : Authenticator
    {
        protected override void AttachToOwinApp(IGalleryConfigurationService config, IAppBuilder app)
        {
            var cookieSecurity = config.Current.RequireSSL ?
                CookieSecureOption.Always :
                CookieSecureOption.Never;

            var options = new CookieAuthenticationOptions
            {
                AuthenticationType = AuthenticationTypes.AcitiveDirectory,
                AuthenticationMode = AuthenticationMode.Active,
                CookieHttpOnly = true,
                CookieSecure = cookieSecurity,
                LoginPath = new PathString("/users/account/LogOn")
            };

            BaseConfig.ApplyToOwinSecurityOptions(options);
            app.UseCookieAuthentication(options);
            app.SetDefaultSignInAsAuthenticationType(AuthenticationTypes.AcitiveDirectory);
        }

        protected internal override AuthenticatorConfiguration CreateConfigObject()
        {
            return new AuthenticatorConfiguration
            {
                AuthenticationType = AuthenticationTypes.AcitiveDirectory,
                Enabled = false
            };
        }

        internal static Task Authenticate(string userNameOrEmail, string password)
        {
            throw new NotImplementedException();
        }
    }
}