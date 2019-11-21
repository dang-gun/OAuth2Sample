using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4_Custom.IdentityServer4.AuthRequest
{
    /// <summary>
    /// http://docs.identityserver.io/en/latest/topics/extension_grants.html
    /// </summary>
    public class MyExtensionGrantValidator : IExtensionGrantValidator
    {
        public string GrantType 
        { 
            get
            {
                return GrantTypeOri;
            }
            set
            {
                this.GrantTypeOri = value;
            }
        }

        private string GrantTypeOri = string.Empty;

        public Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
