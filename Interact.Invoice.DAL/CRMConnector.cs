using System;
using System.Net;
using System.ServiceModel.Description;
using System.Web;
using Interact.Invoice.Common;
using Interact.Invoice.Core.CRMRepositories;
using Interact.Invoice.DAL.CRMRepositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace Interact.Invoice.DAL
{
    public class CrmConnector
    {
        private readonly IOrganizationService _organizationService;
        private UserRole? _userRole = null;
        private Guid _currentUserId;
        public Guid CurrentUserId
        {
            get
            {
                if (_currentUserId != Guid.Empty)
                    return _currentUserId;
                return (_currentUserId = CrmHelper.GetCurrentUserId(CurrentUserName));
            }
        }
        public string CurrentUserName
        {
            get
            {
                var name = HttpContext.Current.User.Identity.Name;
                return name;
            }
        }
        public UserRole UserRole
        {

            get
            {
                if (_userRole.HasValue) return _userRole.Value;
                _userRole = CrmHelper.GetRoleForCurrentUser(CurrentUserName);
                return _userRole.Value;
            }
        }
        public CrmConnector()
        {
            ClientCredentials clientCredentials
                = new ClientCredentials();
            clientCredentials.UserName.UserName = CrmStrings.GetServiceUser();
            clientCredentials.UserName.Password = CrmStrings.GetServicePass();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var orgProxyService = new OrganizationServiceProxy
               (new Uri(CrmStrings.GetServiceUrl()),
                 null, clientCredentials, null);
            _organizationService = orgProxyService;
            orgProxyService.CallerId = CrmHelper.GetCurrentUserId(CurrentUserName);
            _organizationService = orgProxyService;
            // var role = CRMHelper.GetRoleForCurrentUser(CurrentUserName);
        }

        private ICrmHelperRepo _cRmHelper;
        public ICrmHelperRepo CrmHelper => _cRmHelper ?? (_cRmHelper = new CrmHelperRepo(_organizationService));

    }
}
