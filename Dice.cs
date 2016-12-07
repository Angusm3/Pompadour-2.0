using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;

namespace Pompadour_2
{

    public class Dice
    {
        string text = Standby.MessageText.ToLower();

        public DiscordClient D;
        public static string Response = "";
        public Dice()
        {


            if (text.StartsWith("roll "))

            {
                text.ToLower();
                string DCres = "";
                text = text.Replace("roll ", "");
                text = text.Trim();
                bool DCexists = false;

                if (text.Contains("dc"))
                {

                    string[] DC = text.Split(new[] { "dc" }, StringSplitOptions.None);
                    DCexists = true;
                    //e.Channel.SendMessage(DC[0] + ", " + "DC: " + DC[1]);

                    text = DC[0];
                    DCres = DC[1];
                }

                text = text.Trim();


                if (text.Contains("k"))
                {
                    char[] KeepList = { 'd', 'k' };

                    string[] words2 = text.Split(KeepList);

                    int[] DieArray = new int[3];
                    DieArray[0] = 0;
                    DieArray[1] = 0;
                    DieArray[2] = 0;


                    string[] IMDARRAY;
                    IMDARRAY = new string[3];
                    IMDARRAY[0] = "";
                    IMDARRAY[1] = "";
                    IMDARRAY[2] = "0";




                    // IMDARRAY = text.Split('d', '+', '-').ToArray(IMDARRAY);

                    char[] charSeparators;
                    charSeparators = new char[3];
                    charSeparators[0] = 'd';
                    charSeparators[1] = '+';
                    charSeparators[2] = '-';



                    IMDARRAY = text.Split(charSeparators, StringSplitOptions.None);

                    if (IMDARRAY[0].Length > 9)
                    {
                        Response += "\n" + ("die amount exceeds int range");
                        return;
                    }
                    if (IMDARRAY[1].Length > 9)
                    {
                        Response += "\n" + ("die value exceeds int range");
                        return;
                    }




                    try
                    {
                        DieArray = text.Split('d', 'k').Select(str => int.Parse(str)).ToArray();
                    }
                    catch (FormatException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }



                    string[] DieString = DieArray.Select(x => x.ToString()).ToArray();
                    //e.Channel.SendMessage("Rolling KeepDice Function ..  Amount .. " + DieString[0] + " |Die ..  " + DieString[1] + " |Keep .. " + DieString[2]);

                    int Die = DieArray[0];
                    int Roll = DieArray[1];
                    int Keep = DieArray[2];



                    Random rnd = new Random();
                    int[] DieResult = new int[Die];
                    try
                    {
                        for (int i = 0; i < Die; ++i)
                        {
                            int Result = rnd.Next(1, DieArray[1] + 1);
                            DieResult[i] = Result;

                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return;
                    }
                    string ElementString = "";
                    string finaloutput = "";
                    foreach (int Element in DieResult)
                    {
                        ElementString = Element.ToString();
                        finaloutput = finaloutput + ElementString + ", ";

                    }
                    if (finaloutput.Length > 1950)
                    {
                        Response += "\n" + ("string length exceeds 2000 characters");
                    }
                    if (finaloutput.Length < 1950)
                    {
                        Response += "\n" + (finaloutput);
                    }

                    int KeepSum = 0;
                    Array.Sort(DieResult);
                    Array.Reverse(DieResult);
                    for (int i = 0; i < Keep; ++i)
                    {
                        try
                        {
                            KeepSum = KeepSum + DieResult[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }
                    }

                    Response += "\n" + ("Keeping (" + Keep + ") Sum.. " + KeepSum);
                }

                else

                {
                    char[] DieList = { 'd', '+', '-' };


                    string[] words = text.Split(DieList);
                    //                e.Channel.SendMessage("numbers in roll:" + words.Length);

                    int mod = 0;
                    int[] DieArray;
                    DieArray = new int[3];
                    DieArray[0] = 0;
                    DieArray[1] = 0;
                    DieArray[2] = 0;

                    string[] IMDARRAY;
                    IMDARRAY = new string[3];
                    IMDARRAY[0] = "";
                    IMDARRAY[1] = "";
                    IMDARRAY[2] = "0";



                    try
                    {

                        // IMDARRAY = text.Split('d', '+', '-').ToArray(IMDARRAY);

                        char[] charSeparators;
                        charSeparators = new char[3];
                        charSeparators[0] = 'd';
                        charSeparators[1] = '+';
                        charSeparators[2] = '-';



                        IMDARRAY = text.Split(charSeparators, StringSplitOptions.None);
                        try
                        {
                            if (IMDARRAY[0].Length > 9)
                        {
                            Response += "\n" + ("die amount exceeds int range");
                            return;
                        }
                        if (IMDARRAY[1].Length > 9)
                        {
                            Response += "\n" + ("die value exceeds int range");
                            return;
                        }

                            if (IMDARRAY[2].Length > 9)
                            {
                            }
                        }
                        catch
                        {
                            Response = "I can't roll " + text;
                        }

                        DieArray = text.Split('d', '+', '-').Select(str => int.Parse(str)).ToArray();
                    }
                    catch (FormatException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }
                    //
                    // Positive Modifier
                    //
                    try
                    {
                        if (text.Contains("+"))
                        {
                            mod = 0;
                            if (DieArray[2] != 0)
                            {
                                mod = mod + DieArray[2];
                            }
                        }

                        if (DieArray[1] == 0)
                        {
                            return;
                        }

                        var index = Array.FindIndex(DieArray, x => x == 2);
                        Console.WriteLine(text);
                        if (DieArray[1] > 1000)
                            DieArray[1] = 1000;
                        if (DieArray[0] > 500)
                            DieArray[0] = 500;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }
                    //
                    // Negative Modifier
                    //

                    try
                    {
                        if (text.Contains("-"))
                        {
                            mod = 0;
                            if (DieArray[2] != 0)
                            {
                                mod = mod + DieArray[2];
                            }
                        }
                        if (DieArray[1] == 0)
                        {
                            return;
                        }

                        var index = Array.FindIndex(DieArray, x => x == 2);
                        Console.WriteLine(text);
                        if (DieArray[1] > 1000)
                            DieArray[1] = 1000;
                        if (DieArray[0] > 500)
                            DieArray[0] = 500;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }

                    string[] DieString = DieArray.Select(x => x.ToString()).ToArray();
                    string OutputMessage = "";
                    if (mod == 0)
                    {
                        OutputMessage = "Dice Rolled: " + DieString[0] + "d" + DieString[1] + ", DC: " + DCres;
                    }
                    else if (mod > 0 && text.Contains("+"))
                    {
                        OutputMessage = "Dice Rolled: " + DieString[0] + "d" + DieString[1] + "+" + DieString[2] + ", DC: " + DCres;
                    }
                    else if (mod > 0 && text.Contains("-"))
                    {
                        OutputMessage = "Dice Rolled: " + DieString[0] + "d" + DieString[1] + "-" + DieString[2] + ", DC: " + DCres;
                    }



                    if (DCexists == false)
                    {
                        OutputMessage = OutputMessage.Replace("DC:", "");
                    }
                    Response += "\n" + (OutputMessage);


                    Random rnd = new Random();

                    int roll = 0;
                    int rollSum = 0;
                    int total = 0;
                    int ismodified = 0;
                    int ismultiple = 0;
                    string DieOutput = "";
                    for (int i = 0; i < DieArray[0]; ++i)
                    {
                        try
                        {
                            roll = rnd.Next(1, DieArray[1] + 1);

                            total = roll + mod;
                            if (DieArray[0] == 1 && mod == 0)
                            {

                                Response += "\n" + ("Rolled .. " + roll);
                                ismodified = 0;
                                ismultiple = 0;
                            }
                            else if (DieArray[0] == 1 && mod > 0 && text.Contains("+"))
                            {
                                rollSum = rollSum + roll;
                                Response += "\n" + ("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 0;
                            }
                            else if (DieArray[0] > 1 && mod > 0 && text.Contains("+"))
                            {
                                rollSum = rollSum + roll;
                                DieOutput = DieOutput + roll + ", ";
                                //e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 1;
                            }
                            else if (DieArray[0] == 1 && mod > 0 && text.Contains("-"))
                            {
                                rollSum = roll - mod;
                                Response += "\n" + ("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 0;
                            }
                            else if (DieArray[0] > 1 && mod > 0 && text.Contains("-"))
                            {
                                rollSum = rollSum + roll;
                                DieOutput = DieOutput + roll + ", ";
                                //e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 1;
                            }
                            else if (DieArray[0] > 1 && mod == 0)
                            {
                                rollSum = rollSum + roll;
                                DieOutput = DieOutput + roll + ", ";
                                //e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 0;
                                ismultiple = 1;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Response += "\n" + ("pesky bee! " + DieArray[1] + " is not a die!");
                            return;
                        }

                    }
                    try
                    {
                        if (DieOutput.EndsWith(", "))
                        {
                            DieOutput = DieOutput.Remove(DieOutput.Length - 2);
                        }
                        Response += "\n" + (DieOutput);
                    }
                    catch
                    {

                    }
                    int rollTotal = 0;
                    if (ismodified == 1 && ismultiple == 1 && text.Contains("+"))
                    {
                        rollTotal = rollSum + mod;
                        Response += "\n" + ("Sum .. " + DieString[0] + "d" + DieArray[1] + "(" + rollSum + ")" + " + " + DieArray[2] + " = " + rollTotal);
                    }
                    else if (ismodified == 1 && ismultiple == 0 && text.Contains("+"))
                    {
                        rollSum = total;
                        Response += "\n" + ("Sum .. " + DieString[0] + "d" + DieArray[1] + " + " + DieArray[2] + " = " + rollSum);
                    }
                    else if (ismodified == 1 && ismultiple == 1 && text.Contains("-"))
                    {
                        rollTotal = rollSum - mod;
                        Response += "\n" + ("Sum .. " + DieString[0] + "d" + DieArray[1] + "(" + rollSum + ")" + " - " + DieArray[2] + " = " + rollTotal);
                    }
                    else if (ismodified == 1 && ismultiple == 0 && text.Contains("-"))
                    {
                        //rollSum = total;
                        Response += "\n" + ("Sum .. " + DieString[0] + "d" + DieArray[1] + " - " + DieArray[2] + " = " + rollSum);
                    }
                    else if (ismodified == 0 && ismultiple == 1)
                    {
                        Response += "\n" + ("Sum .. " + DieString[0] + "d" + DieArray[1] + " = " + rollSum);
                    }
                    //else if (ismodified == 0 && ismultiple == 0)
                    //{
                    //    return;
                    //}

                    int DCFinal = 0;
                    if (roll > 0)
                    {
                        DCFinal = roll;
                    }
                    if (rollSum > 0)
                    {
                        DCFinal = rollSum;
                    }
                    if (rollTotal > 0)
                    {
                        DCFinal = rollTotal;
                    }



                    //e.Channel.SendMessage("roll: " + roll + "\nrollSum: " + rollSum + "\nrollTotal: " + rollTotal + "\nDCFinal: " + DCFinal + "\nDC: " + DCres);
                    try
                    {

                        int DCn = Int32.Parse(DCres);
                        if (roll == 1)
                        {
                            Response += "\n" + ("Critical Failure");
                        }
                        else if (roll == DieArray[1])
                        {
                            Response += "\n" + ("Critical Success");
                        }
                        else if (DCFinal > DCn)
                        {
                            Response += "\n" + ("Passed");
                        }
                        else if (DCn > DCFinal && DCn > 1)
                        {
                            Response += "\n" + ("Failed");
                        }
                        else if (DCn == DCFinal)
                        {
                            Response += "\n" + ("Player Favour");
                        }

                    }
                    catch
                    { }


                }
            }
        }
    }
}