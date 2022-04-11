using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmWorkPlanningApp {
    public interface IShift {
        public int GetShiftNumber();
        public bool IsValid();
        public string GetSupervisor();
        public DateTime GetDate();
    }
    public abstract class Shift : IShift {
        public static IShift GetShiftFor(int shiftNr) {
            if (shiftNr == 1) return new FirstShift();
            if (shiftNr == 2) return new SecondShift();
            if (shiftNr == 3) return new ThirdShift();

            return new NullShift();
        }

        public abstract int GetShiftNumber();
        public virtual bool IsValid() {
            return true;
        }

        public abstract string GetSupervisor();

        //The date for this shift.
        //Note: Only one hardcoded date for the MVP.
        public DateTime GetDate() {
            return DateTime.Parse("2022-04-01");
        }
    }

    public class FirstShift : Shift {
        public override int GetShiftNumber() {
            return 1;
        }
        public override string GetSupervisor() {
            return "Mr. First Shift Supervisor";
        }
    }

    public class SecondShift : Shift {
        public override int GetShiftNumber() {
            return 2;
        }
        public override string GetSupervisor() {
            return "Dr. Second Shift Supervisor";
        }
    }

    public class ThirdShift : Shift {
        public override int GetShiftNumber() {
            return 3;
        }
        public override string GetSupervisor() {
            return "Ms. Third Shift Supervisor";
        }
    }

    public class NullShift : Shift {
        public override int GetShiftNumber() {
            return -1;
        }
        public override bool IsValid() {
            return false;
        }

        public override string GetSupervisor() {
            return "Invalid Shift : No Supervisor";
        }
    }
}
