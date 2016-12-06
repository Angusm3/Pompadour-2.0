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
            Console.WriteLine("IN STANDBY");
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
            //public static string messagetext = { "text" };
            if (text.Equals("_standby"))
            {
                MessageClass = "standby";
            }
            if (text.Equals("_dice"))
            {
                MessageClass = "dice";
            }


            if (MessageClass.Equals("dice"))
            {
                Console.WriteLine("ENTERRING DICE");
                Dice D = new Pompadour_2.Dice();
            }


        }
    }
}
