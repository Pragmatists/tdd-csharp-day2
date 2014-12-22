namespace Employee
{
    internal class CeoSalaryStrategy : ISalaryStrategy
    {
        public virtual double Salary(Employee employee)
        {
            return employee.Base + employee.Achievements*employee.AchievementsFactor
                   + employee.CompanyResult*0.01;
        }
    }
}