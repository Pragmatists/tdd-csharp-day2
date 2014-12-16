using System;
using System.Net;

namespace ReportGenerator
{
    internal class LegacyDatabase
    {
        private string content;

        public void Connect()
        {
            content = new WebClient().DownloadString("http://localhost:4567/hi");
        }

        public UserData GetDataFor(User user)
        {
            return new UserData(Boolean.Parse(content));
        }
    }
}