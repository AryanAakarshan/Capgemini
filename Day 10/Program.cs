using System;
using System.Text.RegularExpressions;
using LogProcessing;
namespace LogProcessing
{
    public class LogParser
    {
        private readonly string validLineRegexPattern;
        private readonly string splitLineRegexPattern;
        private readonly string quotedPasswordRegexPattern;
        private readonly string endOfLineRegexPattern;
        private readonly string weakPasswordRegexPattern;
        public bool IsValidLine(string text)
        {
            bool check=Regex.IsMatch(text,@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
            return check;
        }
        public string[] SplitLogLine(string text)
        {
            string pattern = @"<[\^*=]>|<====>|<\^\*>";
            return Regex.Split(text, pattern);
        }
        public int CountQuotedPasswords(string lines)
        {
            string pattern = @"^password\w+";
            return Regex.Matches(lines, pattern,RegexOptions.IgnoreCase).Count;
        }
        public string RemoveEndOfLineText(string line)
        {
            string pattern = @"end-of-line\d+";

            return Regex.Replace(line, pattern, "");
        }
        public string[] ListLinesWithPasswords(string[] lines)
    {

        string pattern = @"password[a-zA-Z0-9]+";
        string[] result = new string[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            Match match = Regex.Match(lines[i], pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                result[i] = $"{match.Value}: {lines[i]}";
            else
                result[i] = $"--------: {lines[i]}";
        }

        return result;
    }


    }
}


class Program
{
    static void Main()
    {
        // string Sentence="abc123";
        // String Pattern=@"\d";
        // string Sentence="123_123";
        // string Sentence="Is this true chat";

        // bool digitCheck=Regex.IsMatch(Sentence,Pattern);
        // Console.WriteLine(digitCheck);
        // String Pattern=@"\d+";
        // string Sentence="Amount: 5000 and 6000 ";
        // string Sentence="123";
        // String Pattern=@"\d*";
        // Match m= Regex.Match(Sentence,Pattern);
        // Console.WriteLine(m.Value);
        // string Sentence="10_20_hello Everyone_30";
        // String Pattern=@"\d+";
        // string Sentence="Aryan 1278 Is here";
        // String Pattern=@"\D+";
        // string Sentence="HelloAryan1278Ishere!?@ _0!\tHello c:\abc\file.txt is here also?Hello";
        // string Sentence="2003-12-26 , 1990-01-01, 2025";

        // string Sentence="c:\\Aryan\\he ";
        // String Pattern=@"\w+";
        // String Pattern=@"\W+";
        // String Pattern=@"\s";
        // String Pattern=@"\.txt";
        // String Pattern=@"\\";
        // string Pattern = @"\?";
        // string Pattern = @"lo$";
        // string Pattern = @"Hello$";
        // string Pattern = @"^Hello";
        // string Pattern = @"^Hello$";
        // string Pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
        // MatchCollection matches=Regex.Matches(Sentence,Pattern);
        // Match m= Regex.Match(Sentence,Pattern);
        
        // // Console.WriteLine(m);
        // foreach(Match mat in matches){
        // Console.WriteLine(mat);
        // Console.WriteLine(mat.Groups["year"].Value);
        // Console.WriteLine(mat.Groups[3].Value);
        // }
        // string Pattern = @"a...e";
        // string Sentence="grapple , apple , a123e , a!@#e";

        // MatchCollection matches=Regex.Matches(Sentence,Pattern);
        
        // foreach(Match mat in matches){
        // Console.WriteLine(mat);
        // }
    //     List<string> Emails = new List<string>
    //     {   
    //     "john.doe@gmail.com",
    //     "alice_123@yahoo.in",
    //     "mark.smith@company.com",
    //     "support-abc@banking.co.in",
    //     "user.nametag@domain.org",
    //     "john.doe@gmail",          // Missing domain extension
    //     "alice@@yahoo.com",        // Double @
    //     "mark.smith@.com",         // Domain missing name
    //     "support@banking..com",    // Double dot in domain
    //     "user name@gmail.com",     // Space not allowed
    //     "@domain.com",             // Missing username
    //     "admin@domain",            // No top-level domain
    //     "info@domain,com",         // Comma instead of dot
    //     "financedept@corp.com.in",   // Invalid character #
    //     "plainaddress"             // Missing @ and domain
    //     };
    //     string Pattern = @"\b^[\w.-]+@[\w-]+(\.\w{2,})+$\b";

    //  foreach (string email in Emails)
    //     {
    //         if (Regex.IsMatch(email, Pattern))
    //         {
    //             Console.WriteLine($"{email}  --> Valid");
    //         }
    //         else
    //         {
    //             Console.WriteLine($"{email}  --> Invalid");
    //         }
    //     }
    LogParser logg = new LogParser();
    Console.WriteLine("TASK 1: Validate Log Line");
        Console.WriteLine(logg.IsValidLine("[INF] Application started")); // true
        Console.WriteLine(logg.IsValidLine("INF Application started"));   // false
        Console.WriteLine();

        // ---- Task 2 ----
        Console.WriteLine("TASK 2: Split Log Line");
        string log = "[INF] User login<***>Session created<====>Access granted";
        string[] parts = logg.SplitLogLine(log);
        foreach (var part in parts)
            Console.WriteLine(part);
        Console.WriteLine();

        // ---- Task 3 ----
        Console.WriteLine("TASK 3: Count Quoted Passwords");
        string logs = @"User said ""password123 is weak""
Admin noted ""PASSWORD456 expired""
No issue found";
        Console.WriteLine(logg.CountQuotedPasswords(logs)); // 2
        Console.WriteLine();

        // ---- Task 4 ----
        Console.WriteLine("TASK 4: Remove End-of-Line Marker");
        string clean = logg.RemoveEndOfLineText("Transaction completed successfully end-of-line456");
        Console.WriteLine(clean);
        Console.WriteLine();

        // ---- Task 5 ----
        Console.WriteLine("TASK 5: Identify Weak Passwords");
        string[] lines =
        {
            "User entered password123 during login",
            "System startup completed",
            "Admin reset passwordABC",
            "Backup process finished"
        };

        string[] output = logg.ListLinesWithPasswords(lines);
        foreach (var line in output)
            Console.WriteLine(line);


    }
}