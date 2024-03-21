using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class MailBook
    {
        private List<Friend> _friends;
        public List<Friend> Friends { get { return _friends; } }
        public MailBook()
        {
            _friends= new List<Friend>();
            ReadCSV();
        }
        public string CountFriends()
        {
            return $"{_friends.Count()} friends in the address book:";
        }
        public void SaveToCsv(string name,string email)
        {
            //Saving persons information to csv
            using (FileStream fs = new FileStream(@"C:\Projects\friends.csv", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    StringBuilder output = new StringBuilder();
                    output.AppendLine(string.Join(";", new String[] { name, email }));

                        sw.Write(output);
                }
            }
            _friends.Add(new Friend() { Name=name,Email=email});
        }
        private void ReadCSV()
        {
            //readin csv at the start of the program
            // csv file has to be on the given path, otherwise code wont work!
            using (var reader = new StreamReader(@"C:\Projects\friends.csv"))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    _friends.Add(new Friend { Name = values[0], Email = values[1] });
                }
            }
        }
    }
}
