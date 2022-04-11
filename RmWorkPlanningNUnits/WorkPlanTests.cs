using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

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
            List<Worker> workers = GetObjectResultContent(_workPlanController.GetWorkerList());
            Assert.AreEqual(0, workers.Count);

            //(1) Setup the first Worked
            Worker alice = GetObjectResultContent(_workPlanController.CreateWorkerNamed("Alice"));
            Assert.IsNotNull(alice);
            Assert.AreEqual("Alice", alice._name);
            int aliceId = alice._id;
            Assert.IsTrue(aliceId > 0);

            Worker alice2 = GetObjectResultContent<Worker>(_workPlanController.GetWorkerByName("Alice"));
            Assert.IsNotNull(alice2);
            Assert.AreEqual("Alice", alice2._name);

            Worker alice3 = GetObjectResultContent<Worker>(_workPlanController.GetWorkerById(aliceId));
            Assert.IsNotNull(alice3);
            Assert.AreEqual("Alice", alice3._name);

            Assert.AreEqual(1, workers.Count);

            //(2.1) Add a shift for this worker : Ok
            int aliceShiftNr = 2;
            ActionResult<IShift> actionResult =_workPlanController.AddShiftForWorker(aliceShiftNr, aliceId);
            IShift addedShift = GetObjectResultContent(actionResult);
            Assert.IsNotNull(addedShift);
            Assert.IsInstanceOf(typeof(SecondShift), addedShift);
            Assert.AreEqual(aliceShiftNr, addedShift.GetShiftNumber());

            //(2.2) Try to set another shift for this same worker : Failure
            actionResult = _workPlanController.AddShiftForWorker(3, aliceId);
            Assert.IsNotNull(actionResult);
            AssertIsBadRequest(actionResult.Result);

            //(2.3) Try to set an Invalid shift for a new worker : Failure
            Worker bob = GetObjectResultContent(_workPlanController.CreateWorkerNamed("Bob"));
            Assert.IsNotNull(bob);
            Assert.AreEqual("Bob", bob._name);
            int bobId = bob._id;
            Assert.IsTrue(bobId > 0);

            actionResult = _workPlanController.AddShiftForWorker(4, bobId); //invalid shiftNr
            Assert.IsNotNull(actionResult);
            AssertIsBadRequest(actionResult.Result);

            //(3.1) Remove an invalid shift for Alice
            actionResult = _workPlanController.RemoveShiftForWorker(6, aliceId);
            Assert.IsNotNull(actionResult);
            AssertIsBadRequest(actionResult.Result);

            //(3.2) Remove the valid shift for Alice
            actionResult = _workPlanController.RemoveShiftForWorker(aliceShiftNr, aliceId);
            Assert.IsNotNull(actionResult);
            IShift removedShift = GetObjectResultContent(actionResult);
            Assert.IsNotNull(removedShift);
            Assert.IsInstanceOf(typeof(SecondShift), removedShift);
            Assert.AreEqual(aliceShiftNr, removedShift.GetShiftNumber());
        }

        //===============================================
        //courtesy https://stackoverflow.com/questions/51489111/how-to-unit-test-with-actionresultt
        private T GetObjectResultContent<T>(ActionResult<T> result) {
            return (T)((ObjectResult)result.Result).Value;
        }
        private void AssertIsBadRequest(ActionResult result) {
            Assert.IsInstanceOf(typeof(BadRequestResult), result);
        }
        //===============================================

        [TearDown]
        public void Cleanup() {
            _workPlanController = null;
        }
    }
}
