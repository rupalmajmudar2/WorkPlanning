
using RmWorkPlanningApp;

namespace RmWorkPlanning {
    public class WorkPlanController {
        private WorkPlanService _workPlanService;
        public WorkPlanController(WorkPlanService workPlanService) {
            _workPlanService = workPlanService;
        }
    }
}
