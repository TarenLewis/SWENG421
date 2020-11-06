using System.Collections.Generic;

namespace Lab10_tbl5256
{
    public abstract class ManagementEmployee : AbstractEmployee
    {
        // public AbstractEmployee boss;

        //AbstractEmployee subordinate;
        //public List<RegularEmployee> subordinateList = new List<RegularEmployee>();
        
        public abstract override void seeDanger(AbstractEmployee source, EmployeeIF boss);
        
        // public AbstractEmployee getSupervisor(){
        //     return (CEO)this.boss;
        // }
    }
}