using NUnit.Framework;

namespace ReportGenerator
{
    // TODO:
    // uruchom test - zaobserwuj że rzuca wyjątkiem, pomimo braku asercji
    // obejrzyj implementację konstruktora new ReportGenerator()
    // i zaobserwuj problematyczne instrukcje
    // zrefaktoryzuj tak, aby test nie rzucał wyjątku
    // zrefaktoryzuj tak, aby udało się napisać asercję
    // zaimplementuj aby test przechodził
    public class ReportGeneratorTest
    {
        [Test]
        public void ShouldGenerateReport()
        {
            new ReportGenerator().GenerateReportFor(AUser("mike"));

            // how to assert that something was written to a file?
            //  Assert.That(report, Is.EqualTo("normal,mike@email.com"));
        }

        private User AUser(string name)
        {
            return new User {Email = name + "@email.com", Name = name};
        }
    }
}