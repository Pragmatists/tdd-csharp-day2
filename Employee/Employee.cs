namespace Employee
{
    public class Employee
    {
        private readonly ISalaryStrategy salaryStrategy;

        public Employee(ISalaryStrategy salaryStrategy)
        {
            this.salaryStrategy = salaryStrategy;
        }

        public EmployeeType Type { get; internal set; }
        public double Base { get; internal set; }
        public double Achievements { get; internal set; }
        public double CompanyResult { get; internal set; }
        public double AchievementsFactor { get; internal set; }

        public enum EmployeeType
        {
            Sales,
            HR,
            Worker,
            CEO
        }

        public double GetSalary()
        {
            return salaryStrategy.Salary(this);
        }
    }

    public interface ISalaryStrategy
    {
        double Salary(Employee employee);
    }
}