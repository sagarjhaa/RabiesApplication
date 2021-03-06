﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RabiesApplication.Web.Startup))]
namespace RabiesApplication.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
