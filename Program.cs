// ask for input

using System.Diagnostics;
int total = 0;
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new();
    // create file
    StreamWriter sw = new("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
    StreamReader rw = new("data.txt");
    while (!rw.EndOfStream)
    {
        string? line = rw.ReadLine();
        
        string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split('|',',');

        
        
        foreach (int i in Enumerable.Range(0, arr.Length))
        {
            
            if (i % 8 == 0)
            {
                
                string[] subs = arr[i].Split('/');
                int d = int.Parse(subs[0]);
                string month = "";
                switch (d)
                {
                    case 1:
                        month = "Jan";
                        break;
                    case 2:
                        month = "Feb";
                        break;
                    case 3:
                        month = "Mar";
                        break;
                    case 4:
                        month = "Apr";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "Jun";
                        break;
                    case 7:
                        month = "Jul";
                        break;
                    case 8:
                        month = "Aug";
                        break;
                    case 9:
                        month = "Sep";
                        break;
                    case 10:
                        month = "Oct";
                        break;
                    case 11:
                        month = "Nov";
                        break;
                    case 12:
                        month = "Dec";
                        break;
                }
                
                Console.WriteLine($"Week of {month}, {subs[1]}, {subs[2]}");
                // unfinished cureently
                Console.WriteLine("Su Mo Tu We Th Fr Sa Tot Avg");
                Console.WriteLine("__ __ __ __ __ __ __ ___ ___");
            }
            
            else
            { 
                if (arr[i].Length < 2)
                {
                    Console.Write($" {arr[i]} ");
                }
                else
                { Console.Write($"{arr[i]} "); }
                if (i % 7 == 0)
                {
                    Console.WriteLine($" {total} {Math.Round(total / 7.0, 1)}");
                    total = 0;
                }
                total = total + int.Parse(arr[i]);
            }
        }
        
        
        
        
    }

}