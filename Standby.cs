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
using System.Threading;

namespace Pompadour_2
{
    public class Standby
    {
        public DiscordClient bot;

        public Standby()
        {
            bot = new DiscordClient();

            bot.ExecuteAndWait(async () =>
            {                
                bot.MessageReceived += BotMsg;
                await bot.Connect("treeforge2.al@gmail.com", "superbotpassword");
            });



        }

        public static string MessageText = "";
        public static string MessageUser = "";
        public static string MessageClass = "";
        public static string MessageTime = "";
        public static string MessageNick = "";
        public static int msgchance = 12;


        public static void BotMsg(object sender, MessageEventArgs e)
        {

            //
            //initial parse
            //
            if (e.Message.IsAuthor) return;
            string text = e.Message.Text;
            text.ToLower();
            MessageText = text;
            MessageUser = e.Message.User.Name;
            MessageTime = e.Message.Timestamp.ToString();
            MessageNick = e.Message.User.ToString();



            //
            //options menu
            //
            if (MessageUser == "Angus" || MessageUser == "hikari")
            {

                if (text.Equals("_standby"))
                {
                    MessageClass = "standby";
                    Console.WriteLine(MessageUser + " activated standby");
                }
                if (text.Equals("_dice"))
                {
                    MessageClass = "dice";
                    Console.WriteLine(MessageUser + " activated dice");
                }
                if (text.Equals("_main"))
                {
                    MessageClass = "main";
                    Console.WriteLine(MessageUser + " activated main");
                }
            }


            if (MessageClass.Equals("dice"))
            {
                    Dice D = new Pompadour_2.Dice();
                    if (Dice.Response != "")
                    {
                        e.Channel.SendMessage(Dice.Response);
                        Dice.Response = "";
                    }
            }
            if (MessageClass.Equals("main"))
            {
                Main M = new Pompadour_2.Main();
                if (Main.Response != "")
                {
                    int rdtimer = (text.Length * 150) + 2000;
                    Thread.Sleep(rdtimer);
                    e.Channel.SendIsTyping();
                    Thread.Sleep(Main.Delay);
                    e.Channel.SendMessage(Main.Response);
                    Main.Response = "";
                    msgchance += 4;

                }
            }
        }
    }
}
