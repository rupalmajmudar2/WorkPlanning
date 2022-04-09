using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmWorkPlanningApp {
    public class IWorkPlanRepository {
        public List<Worker> _workers;
    }
    public class WorkPlanRepository : IWorkPlanRepository {
        public WorkPlanRepository() {
            _workers = new List<Worker>();
        }
    }
}
