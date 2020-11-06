using System;
using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public class Manager : ManagementEmployee
    {
        // The manager will gather information from all his/her managed 
        // supervisors or project leaders and then contact the CEO.


        public Decision decision;
        List<CommunicatorIF> communicatorList = new List<CommunicatorIF>();
        public Manager(string managerName, EmployeeIF managerBoss, Decision d)
        {
            this.name = managerName;
            this.boss = managerBoss;
            this.decision = d;
            clockedInEmployee.Add(this);
        }
        public Manager(string managerName, EmployeeIF managerBoss)
        {
            this.name = managerName;
            this.boss = managerBoss;
        }

        public Decision suggestedDecision()
        {
            return decision;
        }

        public void gatherInformation()
        {
            Console.WriteLine("Manager " + this.name + " gathering information:");
            AbstractEmployee tempEmployee;
            foreach (CommunicatorIF communicator in this.subordinateList)
            {
                tempEmployee = (AbstractEmployee)communicator;
                Console.WriteLine("Communicator " + tempEmployee.name + " providing information: " + communicator.provideInfo());
            }
            Console.WriteLine("");
        }

        // The manager runs “void seeDanger()” to handle the danger by 
        // gathering information from all supervisors under his management 
        // and execute “void contactBoss()” to inform CEO. 
        public override void seeDanger(AbstractEmployee source, EmployeeIF bossMan)
        {
            Console.WriteLine("Manager " + this.name + " becomes aware of danger, gathering information from subordinate supervisors.");
            gatherInformation();
            // and execute “void contactBoss()” to inform CEO. 
            contactBoss();
        }

        public void contactBoss()
        {
            Console.WriteLine("Manager " + this.name + " informing the CEO " + this.boss.getName() + " of the situation");
            boss.seeDanger(this, this.boss);
        }
    }
}