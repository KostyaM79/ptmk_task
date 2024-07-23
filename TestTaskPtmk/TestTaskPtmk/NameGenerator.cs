using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace TestTaskPtmk
{
    public class NameGenerator
    {
        private Random rnd = new Random(DateTime.Now.Millisecond);
        private Dictionary<string, string[]> males = new Dictionary<string, string[]>();
        private Dictionary<string, string[]> females = new Dictionary<string, string[]>();

        public NameGenerator()
        {
            LoadNames();
        }

        public void Generate(WorkersCollection workers, int count)
        {
            int fCount = 0;

            for (int i = 0; i < count;)
            {
                string s;
                Dictionary<string, string[]> names = GetNamesCollection(out s);
                string[] lns = names["LastNames"];
                string[] fns = names["FirstNames"];
                string[] pns = names["Patronymics"];

                string ln = lns[rnd.Next(0, lns.Length)];
                string fn = fns[rnd.Next(0, fns.Length)];
                string pn = pns[rnd.Next(0, pns.Length)];
                string sex = s;

                if (ln[0] == 'F' && sex == "Male")
                {
                    if (fCount < 100)
                    {
                        workers.Create($"{ln} {fn} {pn}", GetDate(), sex);
                        fCount++;
                        i++;
                    }
                }

                else
                {
                    workers.Create($"{ln} {fn} {pn}", GetDate(), sex);
                    i++;
                }
            }
        }

        private void LoadNames()
        {
            using (FileStream fs = File.OpenRead(@"..\..\names.json"))
            {
                JsonDocument doc = JsonDocument.Parse(fs);
                males.Add("LastNames", doc.RootElement.GetProperty("Males").GetProperty("LastNames").Deserialize<string[]>());
                males.Add("FirstNames", doc.RootElement.GetProperty("Males").GetProperty("FirstNames").Deserialize<string[]>());
                males.Add("Patronymics", doc.RootElement.GetProperty("Males").GetProperty("Patronymics").Deserialize<string[]>());

                females.Add("LastNames", doc.RootElement.GetProperty("Females").GetProperty("LastNames").Deserialize<string[]>());
                females.Add("FirstNames", doc.RootElement.GetProperty("Females").GetProperty("FirstNames").Deserialize<string[]>());
                females.Add("Patronymics", doc.RootElement.GetProperty("Females").GetProperty("Patronymics").Deserialize<string[]>());
            }
        }

        private Dictionary<string, string[]> GetNamesCollection(out string sex)
        {
            int c = rnd.Next(0, 2);
            if (c > 0)
            {
                sex = "Male";
                return males;
            }
            else
            {
                sex = "Female";
                return females;
            }
        }

        private DateTime GetDate()
        {
            DateTime startDate = DateTime.Today.AddYears(-80);
            DateTime endDate = DateTime.Today.AddYears(-20);
            int days = (endDate - startDate).Days;
            return startDate.AddDays(rnd.Next(0, days));
        }
    }
}
