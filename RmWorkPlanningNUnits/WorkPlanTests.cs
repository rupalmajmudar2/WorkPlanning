using NUnit.Framework;

using RmWorkPlanning;

using RmWorkPlanningApp;

namespace RmWorkPlanningNUnits {
    [TestFixture]
    public class WorkPlanTests {
        private WorkPlanController _workPlanController;

        [SetUp]
        public void Init() {
            WorkPlanRepository workPlanRepo = new WorkPlanRepository();
            WorkPlanService workPlanService = new WorkPlanService(workPlanRepo);
            _workPlanController = new WorkPlanController(workPlanService);
        }

        [Test]
        [TestCase]
        public void TestStart() {
            Assert.AreEqual(0, _workPlanController.GetWorkerList().Count);

        }

        [TearDown]
        public void Cleanup() {
            _workPlanController = null;
        }
    }
}
