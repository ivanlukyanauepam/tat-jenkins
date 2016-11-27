﻿namespace ConsoleApp
{
    using System;

    using ILuFramework;

    using log4net;

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

            if (Browser.Driver != null)
            {
                var driver = Browser.Driver;
                log.Info(driver.Url);
            }

            Console.ReadKey();
        }
    }
}
