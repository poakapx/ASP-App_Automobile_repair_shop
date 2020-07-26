using Automobile_repair_shop.Models;
using Automobile_repair_shop.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;

namespace Automobile_repair_shop.Pages.Admin
{
    public partial class Services : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Service> GetServices() => repository.Services;

        public void UpdateService(int serviceID)
        {
            Service myService = repository.Services.Where(p => p.ServiceId == serviceID).FirstOrDefault();
            if(myService != null && TryUpdateModel(myService, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveService(myService);
            }
        }

        public void DeleteService(int serviceID)
        {
            Service myService = repository.Services.Where(p => p.ServiceId == serviceID).FirstOrDefault();
            if(myService != null)
            {
                repository.DeleteService(myService);
            }
        }
        public void InsertService()
        {
            Service myService = new Service();
            if (TryUpdateModel(myService, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveService(myService);
            }
        }
    }
}