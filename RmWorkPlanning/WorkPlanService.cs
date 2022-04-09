using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmWorkPlanningApp {
    public class IWorkPlanService {
    }
    public class WorkPlanService : IWorkPlanService {
        private IWorkPlanRepository _workPlanRepo;

        public WorkPlanService(IWorkPlanRepository workPlanRepo) {
            _workPlanRepo = workPlanRepo;
        }
    }
}
