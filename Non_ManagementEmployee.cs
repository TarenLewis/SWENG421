namespace Lab10_tbl5256
{
    public abstract class Non_ManagementEmployee : AbstractEmployee
    {
        //public AbstractEmployee boss;

        public abstract override void seeDanger(AbstractEmployee source, EmployeeIF boss);
        
    }
}