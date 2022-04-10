using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RmWorkPlanningApp {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddScoped(IWorkPlanRepository, WorkPlanRepository);

        }
        // Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app) {
        }
    }
}
