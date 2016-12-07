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



        public static void BotMsg(object sender, MessageEventArgs e)
        {
            string text = e.Message.Text;
            text.ToLower();
            MessageText = text;
            MessageUser = e.Message.User.Name;

            if (MessageUser == "Angus" || MessageUser == "hikari")
            {

                if (text.Equals("_standby"))
                {
                    MessageClass = "standby";
                    Console.WriteLine("Admin detected");
                    Console.WriteLine(MessageUser + " activated standby");
                }
                if (text.Equals("_dice"))
                {
                    MessageClass = "dice";
                    Console.WriteLine("Admin detected");
                    Console.WriteLine(MessageUser + " activated dice");
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

        }
    }
}
