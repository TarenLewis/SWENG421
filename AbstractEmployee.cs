using System;
using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public abstract class AbstractEmployee : EmployeeIF
    {
        internal string name;
        internal List<EmployeeIF> subordinateList = new List<EmployeeIF>();
        internal EmployeeIF boss;


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