using System;

namespace Lab10_tbl5256
{
    public class RegularEmployee : Non_ManagementEmployee
    {

        public RegularEmployee(string regularName, EmployeeIF regularBoss)
        {
            this.name = regularName;
            this.boss = regularBoss;
            clockedInEmployee.Add(this);
        }
        // When a regular employee identifies a danger, 
        // the issue is reported to his/her supervisor or project leader.
        public override void seeDanger(AbstractEmployee source, EmployeeIF bossMan)
        {

            if (this.boss != null)
            {
                Console.WriteLine("Regular Employee sees danger, reporting to their boss " + this.boss.getName() + ".\n");
                bossMan.seeDanger(this, this.boss);
            }
        }
        
        //The fixIt() method prints out a message like “The employee 
        // [name] is fixing it.”
        public void fixIt()
        {
            Console.WriteLine("The employee " + this.name + " is fixing the issue.");
        }
    }
}