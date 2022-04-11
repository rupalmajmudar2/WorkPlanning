
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using RmWorkPlanningApp;

namespace RmWorkPlanning {
    public class WorkPlanController : ControllerBase {
        private IWorkPlanService _workPlanService;
        public WorkPlanController(WorkPlanService workPlanService) {
            _workPlanService = workPlanService;
        }

        public IWorkPlanService GetService() {
            return _workPlanService;
        }

        [HttpGet]
        public ActionResult<List<Worker>> GetWorkerList() {
            return Ok(GetService().GetWorkerList());
        }

        public ActionResult<Worker> CreateWorkerNamed(string workerName) {
            Worker newWorker = GetService().CreateWorkerNamed(workerName);
            if (newWorker == null) return new BadRequestResult();

            return Created("workplanurl", newWorker);
        }

        public ActionResult<Worker> GetWorkerById(int workerId) {
            Worker worker = GetService().GetWorkerById(workerId);
            return Ok(worker);
        }

        public ActionResult<Worker> GetWorkerByName(string workerName) {
            Worker worker = GetService().GetWorkerByName(workerName);
            return Ok(worker);
        }

        //===================================================

        public ActionResult<IShift> AddShiftForWorker(int shiftNr, int workerId) {
            ServiceReturnObject<IShift> shiftSro = GetService().AddShiftForWorker(shiftNr, workerId);
            if (shiftSro._returnValue == null) return new BadRequestResult();

            IShift addedShift = shiftSro._returnValue;
            return new ObjectResult(addedShift);
        }

        public ActionResult<IShift> RemoveShiftForWorker(int shiftNr, int workerId) {
            ServiceReturnObject<IShift> shiftSro = GetService().RemoveShiftForWorker(shiftNr, workerId);
            if (shiftSro._returnValue == null) return new BadRequestResult();

            IShift removedShift = shiftSro._returnValue;
            return new ObjectResult(removedShift);
        }
    }
}
