namespace Employee
{
    internal class HrSalaryStrategy : ISalaryStrategy
    {
        public virtual double Salary(Employee employee)
        {
            return employee.Base + employee.CompanyResult*0.0000002;
        }
    }
}