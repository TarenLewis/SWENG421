using System;

namespace Lab10_tbl5256
{
    public class XYZ
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Decision d1 = new Decision();
            d1.decisionMade = "Fix the problem then evacuate the building.";

            Decision d2 = new Decision();
            d2.decisionMade = "Evacuate now without fixing the problem.";


            CEO Steve = new CEO("Steve", null);
            Manager Bob = new Manager("Bob", Steve, d1);
            Manager Rachel = new Manager("Rachel", Steve);
            Rachel.decision = d2;

            // Team
            Supervisor Jack = new Supervisor("Jack", Bob);
            RegularEmployee John = new RegularEmployee("John", Jack);
            RegularEmployee Mary = new RegularEmployee("Mary", Jack);
            RegularEmployee Jane = new RegularEmployee("Jane", Jack);
            RegularEmployee Tom = new RegularEmployee("Tom", Jack);
            RegularEmployee Nick = new RegularEmployee("Nick", Jack);
            Jack.subordinateList.Add(John);
            Jack.subordinateList.Add(Mary);
            Jack.subordinateList.Add(Jane);
            Jack.subordinateList.Add(Tom);
            Jack.subordinateList.Add(Nick);

            // Team Supervisor Jeff
            Supervisor Jeff = new Supervisor("Jeff", Bob);
            RegularEmployee Rob = new RegularEmployee("Rob", Jeff);
            RegularEmployee Ed = new RegularEmployee("Ed", Jeff);
            RegularEmployee Rick = new RegularEmployee("Rick", Jeff);
            RegularEmployee Michael = new RegularEmployee("Michael", Jeff);
            Jeff.subordinateList.Add(Rob);
            Jeff.subordinateList.Add(Ed);
            Jeff.subordinateList.Add(Rick);
            Jeff.subordinateList.Add(Michael);

            // Team Projectleader Chuck
            ProjectLeader Chuck = new ProjectLeader("Chuck", Rachel);
            RegularEmployee Joe = new RegularEmployee("Joe", Chuck);
            RegularEmployee Frank = new RegularEmployee("Frank", Chuck);
            RegularEmployee Sam = new RegularEmployee("Sam", Chuck);
            RegularEmployee Greg = new RegularEmployee("Greg", Chuck);
            Chuck.subordinateList.Add(Joe);
            Chuck.subordinateList.Add(Frank);
            Chuck.subordinateList.Add(Sam);
            Chuck.subordinateList.Add(Greg);

            // Team ProjectLeader Denise
            ProjectLeader Denise = new ProjectLeader("Denise", Rachel);
            RegularEmployee Amy = new RegularEmployee("Amy", Denise);
            RegularEmployee Wil = new RegularEmployee("Wil", Denise);
            RegularEmployee Nancy = new RegularEmployee("Nancy", Denise);
            RegularEmployee Adam = new RegularEmployee("Adam", Denise);
            // Add subordinates of Project Leaders
            Denise.subordinateList.Add(Amy);
            Denise.subordinateList.Add(Wil);
            Denise.subordinateList.Add(Nancy);
            Denise.subordinateList.Add(Adam);

            // Add subordinates of Managers
            Bob.subordinateList.Add(Jack);
            Bob.subordinateList.Add(Jeff);
            Rachel.subordinateList.Add(Chuck);
            Rachel.subordinateList.Add(Denise);

            // Add subordinates of CEO
            Steve.subordinateList.Add(Bob);
            Steve.subordinateList.Add(Rachel);


            John.seeDanger(John, Jack);
        }
    }
}