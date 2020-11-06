using System;
using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public class CEO : AbstractEmployee
    {
        public CEO(string ceoName, EmployeeIF ceoBoss)
        {
            this.name = ceoName;
            this.boss = ceoBoss;
            clockedInEmployee.Add(this);
        }
        Random r = new Random();
        Decision finalDecision;
        int decisionChoice;
        int max;

        List<Decision> decisionList = new List<Decision>();
        // The CEO will throw a meeting demanding all managers to come up with a set 
        // of decisions. The CEO will randomly pick one of the decisions.
        // The CEO will randomly pick one of the decisions.

        // The CEO run “void seeDanger()” to throw a meeting to discuss with 
        // the managers, and collect suggested decisions from individual managers
        // who perform their implemented “Decision suggestedDecision()” method. 

        // The CEO grants the final decision by method 
        // “Decision grant(Decision[] da)”. 

        // The CEO receives one decision from each manager. He randomly grants
        //  a decision that he receives. 

        public Decision grant(List<Decision> da)
        {
            max = da.Count;
            decisionChoice = r.Next(0, max);
            return da[decisionChoice];
        }

        public override void seeDanger(AbstractEmployee source, EmployeeIF boss)
        {
            //  The CEO receives one decision from each manager.
            Console.WriteLine("Collecting the managers decisions: ");
            foreach (Manager manager in this.subordinateList)
            {
                Console.WriteLine("Adding manager " + manager.name + " decision: [" + manager.decision.decisionMade + "] to the decision list.");
                decisionList.Add(manager.suggestedDecision());
            }

            finalDecision = grant(decisionList);
            Console.WriteLine("The CEO's final decision is: [" + finalDecision.decisionMade + "]");

            // The evacuation is broadcasted from CEO to all employees and the 
            // evacuation procedure must start with regular employees first, 
            // then supervisors and leaders, managers next, and finally the CEO. 
            // Basically, a person’s evacuate() method is called to evacuate and 
            // the method displays “The employee [name] is evacuating”.
            finalDecision.doIt(this);
            
        }

        // public void evacuate()
        // {
            
        // }
    }
}