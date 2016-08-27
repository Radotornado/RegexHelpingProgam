using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace regexTry
{
    public class Program
    {
        public static void Main()
        {
            // This program was created to ease my work to make a stepper motor to sing "Super Mario" theme song
            // I got the frequencies and delay from http://wiki.mikrotik.com/wiki/Super_Mario_Theme
            // The regex for frequency and length
            Regex rgxFreq = new Regex(@"\:(\w+)\s(\w+)\=(\d+)\s(\w+)\=(\d+)\w+;");
            // Second regex for the delay
            Regex rgxDelay = new Regex(@"\:(\w+)\s(\d+)\w+;");
            // List to store arduino commands
            List<string> listArdCom = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                Match matchBeep = rgxFreq.Match(input);
                // Checks for match
                if (matchBeep.Success)
                {
                    string freqVal = matchBeep.Groups[3].Value;
                    string allFirst = "motorStep(" + freqVal + ");";
                    // Store everything in a list
                    listArdCom.Add(allFirst);
                }
                Match matchDelay = rgxDelay.Match(input);
                if (matchDelay.Success)
                {
                    string delayVal = matchDelay.Groups[2].Value;
                    string allSecond = "delay(" + delayVal + ");";
                    // Store everything in a list
                    listArdCom.Add(allSecond);
                }
            }
            foreach (var item in fRow)
            {
                Console.WriteLine(item);
            }
        }
    }
}
