namespace Employee
{
    internal class WorkerSalaryStrategy : ISalaryStrategy
    {
        public virtual double Salary(Employee employee)
        {
            return employee.Base;
        }
    }
}