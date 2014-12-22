namespace Employee
{
    internal class SalesSalaryStrategy : ISalaryStrategy
    {
        public virtual double Salary(Employee employee)
        {
            return employee.Base + employee.AchievementsFactor*employee.Achievements
                   + employee.CompanyResult*0.0000001;
        }
    }
}