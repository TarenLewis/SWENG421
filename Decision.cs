using System;
using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public class Decision
    {
        List<AbstractEmployee> tempEmployeeList = new List<AbstractEmployee>();
        public string decisionMade;
        // The doIt() method in the final decision object is invoked.
        // The decision displays “The city’s environmental department is 
        // notified” and demands all employees in the company to evacuate.
        public void doIt(CEO ceo)
        {
            Console.WriteLine("The city’s environmental department is notified\n");
            //Console.WriteLine("The city’s environmental department is notified");
            Console.WriteLine("EVACUATING ALL PERSONNEL: ");

            // while (AbstractEmployee.clockedInEmployee.Count != 0)
            // {
            //     foreach (EmployeeIF employee in AbstractEmployee.clockedInEmployee)
            //     {
            //         if (employee is RegularEmployee){
            //             employee.evacuate();
            //             AbstractEmployee.clockedInEmployee.Remove(employee);
            //         }
            //         else if(employee is Supervisor || employee is ProjectLeader){
            //             employee.evacuate();
            //             AbstractEmployee.clockedInEmployee.Remove(employee);
            //         }
            //         else if(employee is Manager){
            //             employee.evacuate();
            //             AbstractEmployee.clockedInEmployee.Remove(employee);
            //         }
            //         else if(employee is CEO){
            //             employee.evacuate();
            //             AbstractEmployee.clockedInEmployee.Remove(employee);
            //         }

            //     }
            // }
            evalEmployee(ceo);
        }

        public void evalEmployee(AbstractEmployee employee)
        {
            // Employee has no subordinates, evacuate.
            if (!hasSubordinate(employee))
            {
                employee.evacuate();
                return;
            }
            // Employee has subordinates, for each subordinate
            else
            {
                foreach (AbstractEmployee e in employee.subordinateList)
                {
                    // Evaluate for subordinates
                    evalEmployee(e);
                }
                employee.evacuate();
            }
        }

        // Check if employee has subordinate
        public bool hasSubordinate(AbstractEmployee e)
        {
            if (e.subordinateList.Count == 0)
            {
                return false;
            }
            else return true;
        }


    }
}