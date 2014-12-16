using NUnit.Framework;

namespace Employee
{
    internal class EmployeeTest
    {
        [Test]
        public void ShouldCalculateSalaryForCEO()
        {
            // given
            var ceo = new Employee
            {
                Type = Employee.EmployeeType.CEO,
                Base = 100,
                CompanyResult = 100,
                Achievements = 1,
                AchievementsFactor = 2
            };

            // when
            var salary = ceo.GetSalary();

            // then
            Assert.AreEqual(100 + 100*0.01 + 1*2, salary, 1);
        }

        [Test]
        public void ShouldCalculateSalaryForSales()
        {
            // given
            var sales = new Employee
            {
                Type = Employee.EmployeeType.Sales,
                Base = 100,
                CompanyResult = 100,
                Achievements = 1,
                AchievementsFactor = 2
            };


            // when
            double salary = sales.GetSalary();

            // then
            Assert.AreEqual(100 + 100*0.0000001 + 1*2, salary, 1);
        }

        [Test]
        public void ShouldCalculateSalaryForHR()
        {
            // given
            var hr = new Employee
            {
                Type = Employee.EmployeeType.HR,
                Base = 100,
                CompanyResult = 100,
                Achievements = 1,
                AchievementsFactor = 2
            };


            // when
            var salary = hr.GetSalary();

            // then
            Assert.AreEqual(100 + 100*0.0000002, salary, 1);
        }

        [Test]
        public void ShouldCalculateSalaryForWorker()
        {
            // given
            var worker = new Employee
            {
                Type = Employee.EmployeeType.Worker,
                Base = 100,
            };

            // when
            double salary = worker.GetSalary();

            // then
            Assert.AreEqual(100, salary, 1);
        }
    }
}