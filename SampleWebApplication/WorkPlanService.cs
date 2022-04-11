﻿using System.Collections.Generic;

namespace RmWorkPlanningApp {
    public interface IWorkPlanService {
        public List<Worker> GetWorkerList();
        public Worker CreateWorkerNamed(string workerName);
        public Worker GetWorkerById(int workerId);
        public Worker GetWorkerByName(string workerName);
        public ServiceReturnObject<IShift> AddShiftForWorker(int shiftNr, int workerId);
        public ServiceReturnObject<IShift> RemoveShiftForWorker(int shiftNr, int workerId);
    }

    public class WorkPlanService : IWorkPlanService {
        private IWorkPlanRepository _workPlanRepo;

        public WorkPlanService(IWorkPlanRepository workPlanRepo) {
            _workPlanRepo = workPlanRepo;
        }

        public IWorkPlanRepository GetRepo() {
            return _workPlanRepo;
        }

        public List<Worker> GetWorkerList() {
            return GetRepo().GetWorkerList();
        }

        public Worker CreateWorkerNamed(string workerName) {
            if (HasWorkerNamed(workerName)) return null; //No err-msg etc for now. @TODO

            return GetRepo().CreateWorkerNamed(workerName);
        }

        private bool HasWorkerNamed(string workerName) {
            Worker w = GetRepo().GetWorkerByName(workerName);
            return (w != null);
        }

        public Worker GetWorkerById(int workerId) {
            return GetRepo().GetWorkerById(workerId);
        }

        public Worker GetWorkerByName(string workerName) {
            return GetRepo().GetWorkerByName(workerName);
        }

        //=====================================

        public ServiceReturnObject<IShift> AddShiftForWorker(int shiftNr, int workerId) {
            IShift shift = Shift.GetShiftFor(shiftNr);
            Worker worker = GetWorkerById(workerId);
            return GetRepo().AddShiftForWorker(shift, worker);
        }
        public ServiceReturnObject<IShift> RemoveShiftForWorker(int shiftNr, int workerId) {
            IShift shift = Shift.GetShiftFor(shiftNr);
            Worker worker = GetWorkerById(workerId);
            return GetRepo().RemoveShiftForWorker(shift, worker);
        }
    }
}
