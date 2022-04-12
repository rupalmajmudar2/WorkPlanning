using System.Collections.Generic;
using System.Linq;

namespace RmWorkPlanningApp {
    public interface IWorkPlanRepository {
        public List<Worker> GetWorkerList();
        public Worker CreateWorkerNamed(string workerName);
        public Worker GetWorkerById(int workerId);
        public Worker GetWorkerByName(string workerName);
        public ServiceReturnObject<IShift> AddShiftForWorker(IShift shift, Worker Worker);
        public ServiceReturnObject<IShift> RemoveShiftForWorker(IShift shift, Worker Worker);
        public List<Worker> GetWorkersOnShift(IShift shift);
        //public List<Worker, IShift> GetAllWorkersShifts()
    }
    public class WorkPlanRepository : IWorkPlanRepository {
        public List<Worker> _workers;
        public WorkPlanRepository() {
            _workers = new List<Worker>();
        }

        public List<Worker> GetWorkerList() {
            return _workers;
        }

        public Worker CreateWorkerNamed(string workerName) {
            Worker newWorker = new Worker(workerName);
            _workers.Add(newWorker);

            return newWorker;
        }

        public Worker GetWorkerById(int workerId) {
            return _workers.Where(worker => worker._id == workerId).First();
        }

        public Worker GetWorkerByName(string workerName) {
            List<Worker> workers = _workers.Where(worker => worker._name == workerName).ToList();
            if (workers.Count == 0) return null;

            return workers.First();
        }

        public ServiceReturnObject<IShift> AddShiftForWorker(IShift shift, Worker Worker) {
            return Worker.AddShift(shift);
        }
        public ServiceReturnObject<IShift> RemoveShiftForWorker(IShift shift, Worker Worker) {
            return Worker.RemoveShift(shift);
        }

        public List<Worker> GetWorkersOnShift(IShift shift) {
            return _workers.Where(worker => worker._shifts.Contains(shift)).ToList();
        }
    }
}
