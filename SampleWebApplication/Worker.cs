using System;
using System.Collections.Generic;
using System.Linq;

namespace RmWorkPlanningApp {
    public class Worker {
        public int _id { get; }
        public string _name { get; set; }
        public List<IShift> _shifts { get; set; }
        public Worker(string workerName) {
            _id = new Random().Next(100000, 2000000);
            _name = workerName;
            _shifts = new List<IShift>();
        }

        /*
         * Business Rule: Only one shift (of 8hrs) for a Worker
         */
        public ServiceReturnObject<IShift> AddShift(IShift shift) {
            if (HasAShift()) return new ServiceReturnObject<IShift>(null, "Shift already present. Cannot add another.");

            if (shift.IsValid() == false) return new ServiceReturnObject<IShift>(null, "Invalid Shift.");

            _shifts.Add(shift);
            return new ServiceReturnObject<IShift>(shift, "Shift added");
        }

        public bool HasAShift() {
            return _shifts.Count > 0;
        }

        public ServiceReturnObject<IShift> RemoveShift(IShift shift) {
            if (HasShift(shift) == false) return new ServiceReturnObject<IShift>(null, "Shift not present. Ignore.");

            _shifts.Remove(shift);
            return new ServiceReturnObject<IShift>(shift, "Shift removed");
        }

        public bool HasShift(IShift shift) {
            if (!HasAShift()) return false; //zero shifts
            return (_shifts.ElementAt(0).GetShiftNumber().Equals(shift.GetShiftNumber()));
        }
    }
}
