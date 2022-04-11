using System.Collections.Generic;

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
            List<Worker> workers = _workPlanController.GetWorkerList();
            Assert.AreEqual(0, workers.Count);

            Worker alice = _workPlanController.CreateWorkerNamed("Alice").Value;
            Assert.IsNotNull(alice);
            Assert.AreEqual("Alice", alice._name);
            int aliceId = alice._id;
            Assert.IsTrue(aliceId > 0);

            Worker alice2 = _workPlanController.GetWorkerByName("Alice");
            Assert.IsNotNull(alice2);
            Assert.AreEqual("Alice", alice2._name);

            Worker alice3 = _workPlanController.GetWorkerById(aliceId);
            Assert.IsNotNull(alice3);
            Assert.AreEqual("Alice", alice3._name);

            Assert.AreEqual(1, workers.Count);
        }

        [TearDown]
        public void Cleanup() {
            _workPlanController = null;
        }
    }
}
