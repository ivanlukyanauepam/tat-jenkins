﻿namespace ConsoleApp
{
    using System;

    using ILuFramework;

    using log4net;
    /// <summary>
    /// ALL CODE IN THIS PROJECT CONSUMES ANY LIBRARIES WE USE FOR TESTING PURPOSES
    /// AND TNEH WE WILL INCLUDE SOME IN OUR FRAMEWORK OR TEST PROJECT
    /// </summary>
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world!");
            log.Info("Hello world!");
            //Console.WriteLine("Additional test info");
            log.Info("Additional test info");
            //Console.WriteLine("Check git repo commit");
            log.Info("Check git repo commit");

            //if (Browser.Driver != null)
            //{
            //    var driver = Browser.Driver;
            //    log.Info(driver.Url);
            //}

            Console.WriteLine("My User Scope settings throug the Properties.Settings.Default :");
            Console.WriteLine(Properties.Settings.Default.Sex);
            Console.WriteLine(Properties.Settings.Default.MyName);
            Console.WriteLine("Lets change the Sex property at runtime");
            Properties.Settings.Default.Sex = "Female";
            Properties.Settings.Default.Save();
            Console.WriteLine(Properties.Settings.Default.Sex);


            Console.WriteLine("My Application Scope settings throug the Properties.Settings.Default :");
            Console.WriteLine(Properties.Settings.Default.AppType);

            Console.WriteLine("Lets read a new group of settings.");
            Console.WriteLine(Properties.Custom.Default.MyName);

            Console.ReadKey();
        }
    }
}
