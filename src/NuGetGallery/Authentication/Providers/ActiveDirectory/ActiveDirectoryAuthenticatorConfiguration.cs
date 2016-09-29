// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Configuration;
using System.Globalization;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace NuGetGallery.Authentication.Providers.ActiveDirectory
{
    public class ActiveDirectoryAuthenticatorConfiguration : AuthenticatorConfiguration
    {
        public string Domain { get; set; }

        public bool ShowOnLoginPage { get; set; }

        public ActiveDirectoryAuthenticatorConfiguration()
        {
            AuthenticationType = AuthenticationTypes.AcitiveDirectory;
        }

        public override void ApplyToOwinSecurityOptions(AuthenticationOptions options)
        {
                
        }
    }
}
