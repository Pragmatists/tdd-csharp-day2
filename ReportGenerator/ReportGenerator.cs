using System.IO;

namespace ReportGenerator
{
    public class ReportGenerator
    {
        private readonly LegacyDatabase db;

        public ReportGenerator()
        {
            db = new LegacyDatabase();
            db.Connect();
        }


        public void GenerateReportFor(User aUser)
        {
            var data = db.GetDataFor(aUser);
            if (data.IsSpecial)
            {
                File.WriteAllText("report.log", "special," + aUser.Email);
            }
            else
            {
                File.WriteAllText("report.log", "normal," + aUser.Email);
            }
        }
    }
}