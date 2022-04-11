namespace RmWorkPlanningApp {
    public class ServiceReturnObject<T> where T : class {
        public T _returnValue;
        public string _message;

        public ServiceReturnObject(T retVal, string msg) {
            _returnValue = retVal;
            _message = msg;
        }
    }
}
