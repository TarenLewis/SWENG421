using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public abstract class ManagementEmployee : AbstractEmployee
    {

        public List<ObserverIF> observers = new List<ObserverIF>();
        public abstract override void seeDanger(AbstractEmployee source, EmployeeIF boss);
        public void addObserver(ObserverIF observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(ObserverIF observer)
        {
            observers.Remove(observer);
        }

        public void notify()
        {
            if (this.name == "Jeff")
            {
                RegularEmployee regular;
                foreach (ObserverIF observer in observers)
                {
                    regular = (RegularEmployee)observer;
                    regular.notify();
                }
            }

        }
    }
}