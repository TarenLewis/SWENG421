using System;

namespace Lab10_tbl5256
{
    public class ProjectLeader : ManagementEmployee, CommunicatorIF
    {
        public ProjectLeader(string projectLeaderName, EmployeeIF projectLeaderBoss){
            this.name = projectLeaderName;
            this.boss = projectLeaderBoss;
            clockedInEmployee.Add(this);
        }
        public void announceDanger()
        {
            foreach (AbstractEmployee employee in this.subordinateList){
                employee.receiveMessage("Get outta here!");
            }
        }

        public string provideInfo()
        {
            return "Emergency 1 2 3 in the Project Leader section!";
        }

        // The supervisor or leader will announce the danger 
        // to his/her direct subordinates and also report it to his/her manager.
        public override void seeDanger(AbstractEmployee source, EmployeeIF bossMan){
            Console.WriteLine("Project Leader becomes aware of danger, notifying their boss");
            boss.seeDanger(this, boss);
        }
    }
}