using System;

namespace RmWorkPlanningApp {
    public class Worker {
        public int _id { get; }
        public string _name { get; set; }
        public Worker(string workerName) {
            _id = new Random().Next(100000, 2000000);
            _name = workerName;
        }
    }
}
