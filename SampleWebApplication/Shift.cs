using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmWorkPlanningApp {
    public interface IShift {
        public int GetShiftNumber();
        public int GetStartTime(); //24-hr clock 0 to 24
        public int GetEndTime(); //24-hr clock 0 to 24
        public bool IsValid();
        public string GetSupervisor();
        public DateTime GetDate();
        public string GetReportString();
    }
    public abstract class Shift : IShift {
        public static IShift GetShiftFor(int shiftNr) {
            if (shiftNr == 1) return new FirstShift();
            if (shiftNr == 2) return new SecondShift();
            if (shiftNr == 3) return new ThirdShift();

            return new NullShift();
        }

        public abstract int GetShiftNumber();
        public abstract int GetStartTime(); //24-hr clock 0 to 24
        public abstract int GetEndTime(); //24-hr clock 0 to 24
        public virtual bool IsValid() {
            return true;
        }

        //Two shifts are equal if they have the same shift number.
        public override bool Equals(Object obj) {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            }

            IShift anotherShift = (IShift) obj;
            return this.GetShiftNumber() == anotherShift.GetShiftNumber();
        }
        public virtual string GetReportString() {
            return " Has Shift #" + GetShiftNumber()
                    + " From:" + GetStartTime() + " To:" + GetEndTime() + " Hrs.";
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

        public override int GetStartTime() {
            return 0; //0-hrs => midnight
        }
        public override int GetEndTime() {
            return 8; //8am
        }
        public override string GetSupervisor() {
            return "Mr. First Shift Supervisor";
        }
    }

    public class SecondShift : Shift {
        public override int GetShiftNumber() {
            return 2;
        }
        public override int GetStartTime() {
            return 8; //8am
        }
        public override int GetEndTime() {
            return 16; //4pm
        }
        public override string GetSupervisor() {
            return "Dr. Second Shift Supervisor";
        }
    }

    public class ThirdShift : Shift {
        public override int GetShiftNumber() {
            return 3;
        }
        public override int GetStartTime() {
            return 16; //4pm
        }
        public override int GetEndTime() {
            return 24; //midnight
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
        //Should never get called.
        public override int GetStartTime() {
            return -1; //could throw exception too. TODO.
        }
        //Should never get called.
        public override int GetEndTime() {
            return -1; //could throw exception too. TODO.
        }

        public override string GetReportString() {
            return " Has No Shift today.";
        }
        public override string GetSupervisor() {
            return "Invalid Shift : No Supervisor";
        }
    }
}
