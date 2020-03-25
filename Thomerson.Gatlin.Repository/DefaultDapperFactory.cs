//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Thomerson.Gatlin.Repository
//{
//    public class DefaultDapperFactory
//    {
//        private readonly IServiceProvider _services;
//        private readonly IOptionsMonitor<DapperFactoryOptions> _optionsMonitor;

//        public DefaultDapperFactory(IServiceProvider services, IOptionsMonitor<DapperFactoryOptions> optionsMonitor)
//        {
//            _services = services ?? throw new ArgumentNullException(nameof(services));
//            _optionsMonitor = optionsMonitor ?? throw new ArgumentNullException(nameof(optionsMonitor));
//        }

//        public DapperClient CreateClient(string name)
//        {
//            if (name == null)
//                throw new ArgumentNullException(nameof(name));

//            var client = new DapperClient(new ConnectionConfig { });

//            var option = _optionsMonitor.Get(name).DapperActions.FirstOrDefault();
//            if (option != null)
//                option(client.CurrentConnectionConfig);
//            else
//                throw new ArgumentNullException(nameof(option));

//            return client;
//        }
//    }
//}
