using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(QLNX.Startup))]
namespace QLNX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }


}
