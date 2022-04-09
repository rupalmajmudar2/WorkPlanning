using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmWorkPlanningApp {
    public interface IShift {
        public string GetSupervisor();
        public DateTime GetDate();
    }
    public abstract class Shift : IShift {
        public abstract string GetSupervisor();

        //The date for this shift.
        //Note: Only one hardcoded date for the MVP.
        public DateTime GetDate() {
            return DateTime.Parse("2022-04-01");
        }
    }

    public class FirstShift : Shift {
        public override string GetSupervisor() {
            return "Mr. First Shift Supervisor";
        }
    }

    public class SecondShift : Shift {
        public override string GetSupervisor() {
            return "Dr. Second Shift Supervisor";
        }
    }

    public class ThirdShift : Shift {
        public override string GetSupervisor() {
            return "Ms. Third Shift Supervisor";
        }
    }
}
