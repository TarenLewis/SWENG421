using System;

namespace Lab10_tbl5256
{
    public class Supervisor : ManagementEmployee, CommunicatorIF
    {
        // The supervisor runs “void seeDanger()” to tell all his subordinates
        // to perform fixIt() and also informs his manager. 
        // The supervisor or leader will announce the danger 
        // to his/her direct subordinates and also report it to his/her manager.
       public Supervisor(string supervisorName, EmployeeIF supervisorBoss){
           this.name = supervisorName;
           this.boss = supervisorBoss;
           clockedInEmployee.Add(this);
       }
       public void announceDanger()
        {
            foreach (AbstractEmployee employee in this.subordinateList){
                employee.receiveMessage("Get outta here!");
            }
        }

        // The manager runs “void seeDanger()” to handle the danger by 
        // gathering information from all supervisors under his management 
        // and execute “void contactBoss()” to inform CEO. 
        public string provideInfo()
        {
            return "Disaster in the Supervisor section!";
        }

        // The supervisor or leader will announce the danger 
        // to his/her direct subordinates and also report it to his/her manager.
        
        // Supervisor Jeff always sends Rob and Rick to support the other team 
        // that encounters an incidence, i.e., these two guys perform fixIt() 
        // for the other team. 
        public override void seeDanger(AbstractEmployee source, EmployeeIF bossMan){
            Console.WriteLine("Superviser " + this.name + " becomes aware of danger, telling all subordinates to fix it. ");
            foreach(RegularEmployee subordinate in subordinateList){
                subordinate.fixIt();
            }
            Console.WriteLine("\nSuperviser " + this.name + " informing boss " + this.boss.getName() + " of the danger.");
            boss.seeDanger(this, boss);
        }

    }
}