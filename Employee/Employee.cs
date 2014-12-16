using System;

namespace Employee
{
    public class Employee
    {
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
            switch (Type)
            {
                case EmployeeType.Sales:
                    return Base + AchievementsFactor*Achievements
                           + CompanyResult*0.0000001;
                case EmployeeType.HR:
                    return Base + CompanyResult*0.0000002;
                case EmployeeType.Worker:
                    return Base;
                case EmployeeType.CEO:
                    return Base + Achievements*AchievementsFactor
                           + CompanyResult*0.01;
                default:
                    throw new InvalidOperationException("Employee type unspecified");
            }
        }
    }
}