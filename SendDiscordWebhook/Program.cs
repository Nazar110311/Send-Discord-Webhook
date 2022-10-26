using System;

namespace SendDiscordWebhook
{
    class Program
    {
        static void Main(string[] args)
        {
            SendWeebhook sw = new SendWeebhook();
            sw.SendMessage("Your message", "New message!"); //1. message 2. title
            sw.SendFile("sample3.txt", "file.txt"); //1. path to file 2. file name
        }
    }
}
