using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Unity;

namespace Interact.Invoice.Web
{
    public class UnityServiceLocatorAdapter : ServiceLocatorImplBase
    {
        private readonly IUnityContainer _unityContainer;

        public UnityServiceLocatorAdapter(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return _unityContainer.Resolve(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _unityContainer.ResolveAll(serviceType);
        }
    }
}