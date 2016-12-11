using Discord;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;
using System.Web;
using System.Threading;

namespace Pompadour_2
{
    public class Main
    {
        public DiscordClient M;
        public static string Response = "";
        public static int Delay = 0;
        string text = Standby.MessageText.ToLower();
        string user = Standby.MessageUser;
        string LoadedFile = "Character not found";
        public Main()
        {
            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //USER EXCEPTIONS
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------
            if (user.Equals("RecCom1138")) return;
            //if (e.Message.User.Equals("Angus")) return;
            string input = text;






            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //INPUT PARSE
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

            string messagetext = text;
            string messageusername = Standby.MessageNick;
            string messagetime = Standby.MessageTime;

            messagetext = messagetext.ToLower();
            string[] usernick = messageusername.Split('#');
            string messageuser = usernick[0];
            string messageusernumber = usernick[1];

            string consoleout = messagetime + " .. " + messageuser + " .. " + messagetext;


            Console.WriteLine(consoleout);



            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //INPUT EXCEPTIONS
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

            if (text.Contains("http")) return;
            if (text.StartsWith("~")) return;


            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //HELP
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------


            if (text == "!help")
            {
                Response += "\n" + ("@" + user + "\nCurrent Command List:\n!help\nroll XdY+Z or XdYkZ\nPClist\nPC *command*\nwiki |edition, if none leave out| *page name*\nPClist\n+ some hidden commands");
            }







            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //USER SCAN
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------



            if (text.StartsWith(""))
            {

                string text = messagetext;

                //if text contains 'change'  'add'  'whatever'  then string function then remove it and use function for string starts after finding name
                //string function;

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Initializing files array profiles[]
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                string path = @"profiles\";
                int ProfileCount;

                int q = 0;
                var charfiles = Directory.EnumerateFiles(path, "*.*");
                foreach (string currentFile in charfiles)
                {
                    string fileName = currentFile.Substring(path.Length);

                    q += 1;
                }

                string[] profiles = new string[q];
                q = 0;
                foreach (string currentFile in charfiles)
                {
                    string fileName = currentFile.Substring(path.Length);
                    profiles[q] = fileName;
                    q += 1;
                }

                ProfileCount = profiles.Length;

                for (int i = 0; i < ProfileCount; i++)
                {
                    profiles[i] = profiles[i].Replace(".csv", "");

                }

                for (int i = 0; i < ProfileCount; i++)
                {

                    if (text.Contains(profiles[i]))
                    {
                        LoadedFile = profiles[i];
                    }

                }



                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Profile Creation
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                if (!(File.Exists(path + messageuser + ".csv")))
                {
                    Console.WriteLine("Creating " + messageuser + "...");
                    try
                    {
                        using (FileStream fs = File.Create(path + messageuser + ".csv"))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes("");

                            fs.Write(info, 0, info.Length);

                            Console.WriteLine("Profile created for " + messageuser);
                        }
                    }
                    catch
                    {
                        Response += "\n" + "error with file..";
                    }
                }


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Profile Writing
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (File.Exists(path + messageuser + ".csv"))
                {
                    string file = path + messageuser + ".csv";
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(messagetext);
                    }

                }


            }




            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //Pompadour dumb ai
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------


            if (user == "MinusVitaminC")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }

            if (user == "Wedge")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }
            if (user == "hikari")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }



            if (text.Contains("no ") || text.Contains("n't") || text.Contains("not "))
            {
                string path = @"AI\Negative.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                text = text.Replace("pompadour", "%NAM_");
                text = text.Replace("pomp", "%NAM_");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }



            if (text.Contains("greeting") || text.Contains("hello") || text.Contains("hey") || text.Contains("yo ") || text.Contains("sup ") || text.Contains("hai ") || text.Contains("hi ") || text.Contains("wassap"))
            {
                string path = @"AI\Greetings.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                text = text.Replace("pompadour", "%NAM_");
                text = text.Replace("pomp", "%NAM_");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }


















            if (text.Contains("http"))
            {
                string path = @"AI\Links.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
                return;
            }





            if (text.Contains(""))
            {
                string text = "";
                if (text.Contains("pomp"))
                {
                    Standby.msgchance = 20;
                }

            }



            if (text.Contains(""))
            {
                string path = @"AI\PompadourAI.csv";
                string[] outputline = File.ReadAllLines(path);
                var doclength = File.ReadAllLines(path).Length;
                Standby.msgchance -= 1;
                Console.WriteLine("NML .. " + Standby.msgchance);

                Random rnd = new Random();

                int roll = rnd.Next(1, Standby.msgchance + 1);
                int roll2 = rnd.Next(1, doclength + 1);
                string output = "";


                try
                {
                    if (roll == 1)
                    {


                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        Delay = (outputline[roll2].Length) * 50;
                        Console.WriteLine("delay .. " + Delay);
                        Response += "\n" + (outputline[roll2]);

                    }
                }
                catch
                {
                    return;
                }

            }

            /* add greetings
             * fix roll overflow
             * recognize name 
             * replace name with %NAM_
             * 
             * 
             * 
             */




















            if (text.Contains("pompadour") || text.Contains("pomp"))
            {
                Console.WriteLine(text);

                if (text.Contains("shut") || text.Contains("stop") || text.Contains("stupid") || text.Contains("bad") || text.Contains("ultron"))
                {
                    string path = @"AI\Negative.csv";
                    string[] outputline = File.ReadAllLines(path);
                    var doclength = File.ReadAllLines(path).Length;
                    Random rnd = new Random();

                    int roll2 = rnd.Next(1, doclength + 1);
                    string output = "";


                    try
                    {

                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        Delay = (outputline[roll2].Length) * 50;
                        Console.WriteLine("delay .. " + Delay);
                        Response += "\n" + (outputline[roll2]);

                    }
                    catch
                    {
                        return;
                    }
                }







                if (text.Contains("greeting") || text.Contains("hello") || text.Contains("hey") || text.Contains("yo") || text.Contains("sup") || text.Contains("hai") || text.Contains("hi") || text.Contains("wassap"))
                {
                    string path = @"AI\Greetings.csv";
                    string[] outputline = File.ReadAllLines(path);
                    var doclength = File.ReadAllLines(path).Length;
                    Standby.msgchance -= 1;
                    Console.WriteLine("GREET .. " + Standby.msgchance);

                    Random rnd = new Random();

                    int roll = rnd.Next(1, Standby.msgchance + 1);
                    int roll2 = rnd.Next(1, doclength + 1);
                    string output = "";


                    try
                    {
                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        Delay = (outputline[roll2].Length) * 50;
                        text = outputline[roll2];
                        text = text.Replace("%NAM_", user);
                        Console.WriteLine("delay .. " + Delay);
                        Response += "\n" + (outputline[roll2]);

                    }
                    catch
                    {
                        return;
                    }
                }



                if (text.Contains("are you") || text.Contains("what is"))
                {
                    string newfile = @"AI\Response1.csv";

                    if (text.StartsWith("create "))
                    {

                        if (File.Exists(newfile))
                        {
                            string path = newfile;
                            string[] outputline = File.ReadAllLines(path);
                            var doclength = File.ReadAllLines(path).Length;
                            Standby.msgchance -= 1;
                            Console.WriteLine("RESPONSE1 .. " + Standby.msgchance);

                            Random rnd = new Random();

                            int roll = rnd.Next(1, Standby.msgchance + 1);
                            int roll2 = rnd.Next(1, doclength + 1);
                            string output = "";


                            try
                            {
                                output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                                Delay = (outputline[roll2].Length) * 50;
                                text = outputline[roll2];
                                text = text.Replace("%NAM_", user);
                                Console.WriteLine("delay .. " + Delay);
                                Response += "\n" + (outputline[roll2]);

                            }
                            catch
                            {
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                using (FileStream fs = File.Create(newfile))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes("");

                                    fs.Write(info, 0, info.Length);


                                }
                            }
                            catch
                            {
                                Response += "error";
                                return;
                            }

                        }

                    }

                }

            }




            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //Misc. functions
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

            if (text.Contains("the best"))
            {
                Response += "\n" + ("https://www.youtube.com/watch?v=5vRlJrkxsqo");
            }
            if (text.Contains("bustin'"))
            {
                Response += "\n" + ("https://www.youtube.com/watch?v=0tdyU_gW6WE");
            }
            if (text.Contains("and they don't stop coming"))
            {
                Response += "\n" + ("https://www.youtube.com/watch?v=8ZhYNWwbJpQ");
            }
            string[] Crews =
            {
                "https://www.youtube.com/watch?v=6Ajhzlq42f0",
                "https://www.youtube.com/watch?v=fU3jfk-O7L0",
                "https://www.youtube.com/watch?v=yZ15vCGuvH0",
                "https://www.youtube.com/watch?v=Wt7sCW9_DOc",
                "https://www.youtube.com/watch?v=X1M69l7ZGlw",
                "https://www.youtube.com/watch?v=25IhfWRO4Rk",
                "https://www.youtube.com/watch?v=fI4ZhW1anKY",
                "https://www.youtube.com/watch?v=RmEQ9iPQVrE",
                "https://www.youtube.com/watch?v=QFAmaiZxLQw",
                "https://www.youtube.com/watch?v=2tv-P28jVCQ",
                "https://www.youtube.com/watch?v=yYFpVXX-nvA",
                "https://www.youtube.com/watch?v=Bn62N5n3TDw"
            };
            if (text.Equals("old spice"))
            {
                Random rnd = new Random();
                int roll = rnd.Next(1, Crews.Length);
                Response += "\n" + (Crews[roll]);
            }








        }
    }
}