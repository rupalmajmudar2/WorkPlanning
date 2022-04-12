using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RmWorkPlanningApp {
    public class WorkerReport {
        public List<string> GetWorkersShiftsReportFor(List<Worker> workers) {
            return workers.Select(worker => PrintReportRowFor(worker)).ToList();
        }

        //Sample report row
        private string PrintReportRowFor(Worker worker) {
            return 
                "WorkerId#" + worker._id 
                + " : " + worker._name
                + worker.GetShift().GetReportString();
        }
    }
}
