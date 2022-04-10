using System.Collections.Generic;
using System.Linq;

namespace RmWorkPlanningApp {
    public interface IWorkPlanRepository {
        public List<Worker> GetWorkerList();
        public Worker GetWorkerById(int workerId);
        public Worker GetWorkerByName(string workerName);
    }
    public class WorkPlanRepository : IWorkPlanRepository {
        public List<Worker> _workers;
        public WorkPlanRepository() {
            _workers = new List<Worker>();
        }

        public List<Worker> GetWorkerList() {
            return _workers;
        }

        public Worker GetWorkerById(int workerId) {
            return _workers.Where(worker => worker._id == workerId).First();
        }

        public Worker GetWorkerByName(string workerName) {
            return _workers.Where(worker => worker._name == workerName).First();
        }
    }
}
