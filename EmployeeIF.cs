namespace Lab10_tbl5256
{
    public interface EmployeeIF
    {
        public void seeDanger(AbstractEmployee source, EmployeeIF boss);
        public string getName();
        public void evacuate();
    }
}