
using System.Collections.Generic;

using RmWorkPlanningApp;

namespace RmWorkPlanning {
    public class WorkPlanController {
        private IWorkPlanService _workPlanService;
        public WorkPlanController(WorkPlanService workPlanService) {
            _workPlanService = workPlanService;
        }

        public IWorkPlanService GetService() {
            return _workPlanService;
        }

        public List<Worker> GetWorkerList() {
            return GetService().GetWorkerList();
        }

        public Worker GetWorkerById(int workerId) {
            return GetService().GetWorkerById(workerId);
        }

        public Worker GetWorkerByName(string workerName) {
            return GetService().GetWorkerByName(workerName);
        }
    }
}
