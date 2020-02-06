using GameCore.Domain;
using System;

namespace GameCore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Goldorak goldorak = new Goldorak();
                goldorak.UfoState = UfoState.Undocked;
                goldorak.LastMaintenanceDate = new DateTime(2020, 02, 06);
                Console.WriteLine($"Health: {goldorak.Health} UfoState= {goldorak.UfoState} LastMaintainedDate= {goldorak.LastMaintenanceDate}");
                goldorak.Hit(30);
                Console.WriteLine($"Health: {goldorak.Health}");
                goldorak.ReadHealthScroll();
                Console.WriteLine($"Health: {goldorak.Health}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Hit any key to stop ...");
                Console.ReadLine();
            }
        }
    }
}
