using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using RmWorkPlanning;

using RmWorkPlanningApp;

namespace RmWorkPlanningNUnits {
    public class WorkPlanTests {
        private WorkPlanController _workPlanController;

        [SetUp]
        public void Init() {
            WorkPlanRepository workPlanRepo = new WorkPlanRepository();
            WorkPlanService workPlanService = new WorkPlanService(workPlanRepo);
            _workPlanController = new WorkPlanController(workPlanService);
        }

        [Test]
        public void TestStart() {
            //_workPlanController.
        }

        [TearDown]
        public void Cleanup() { 
            _workPlanController = null;
        }
    }
}
