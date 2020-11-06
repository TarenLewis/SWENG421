using System;
using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public abstract class AbstractEmployee : EmployeeIF
    {
        public static List<EmployeeIF> clockedInEmployee = new List<EmployeeIF>();
        internal string name;
        public List<EmployeeIF> subordinateList = new List<EmployeeIF>();
        public EmployeeIF boss;


        public abstract void seeDanger(AbstractEmployee source, EmployeeIF boss);

        public void receiveMessage(string message){
            Console.WriteLine(this.name + " " + " received warning of: " + message);
        }
        public void setName(string str){
            this.name = str;
        }

        public string getName(){
            return name;
        }

        public void evacuate()
        {
            Console.WriteLine("Employee " + this.name + " evacuating.");
        }
    }
}