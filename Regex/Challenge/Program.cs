// See https://aka.ms/new-console-template for more information

//Christos Ebeatu BU/22c/IT/7789

using System.Diagnostics;
using System.Text.RegularExpressions;


string ReverseDateFormat(string datestr) {
    TimeSpan Timeout = TimeSpan.FromSeconds(1);
    
    Stopwatch sw = Stopwatch.StartNew();
    Regex DateMatch = new(@"(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})", RegexOptions.None, Timeout); 
    Match match = DateMatch.Match(datestr);
    sw.Stop();
    
    string month = match.Result("${month}");
    string day = match.Result("${day}");
    string year = match.Result("${year}");
    
    return $"{year}-{day}-{month}";
}

while(true){
    Console.WriteLine("Enter Date(mm/dd/yyyy)");
    string date = Console.ReadLine();
    
    if(date == "exit"){
        break;
    }
    
    if(DateOnly.TryParse(date, out DateOnly _)) {
        Console.WriteLine(ReverseDateFormat(date));
        
    }
    else{
        Console.WriteLine("Invalid date");
    }
    
}
