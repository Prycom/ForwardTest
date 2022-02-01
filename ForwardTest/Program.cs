using System;
using System.Collections.Generic;
using ForwardTest.Creator;
using ForwardTest.Creator.Realization;
using ForwardTest.Engine;
using ForwardTest.Stand;
using ForwardTest.Stand.Realization;
using ForwardTest.Test;
using ForwardTest.Test.Realization;

namespace ForwardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int TAir;
            Console.WriteLine("Введите температуру воздуха");
            try
            {
                TAir = int.Parse(Console.ReadLine());
                Dictionary<string, object> payload = new Dictionary<string, object>()
                {
                    ["I"] = 10,
                    ["M"] = new List<int>() { 20, 75, 100, 105, 75, 0 },
                    ["V"] = new List<int>() { 0, 75, 150, 200, 250, 300 },
                    ["T"] = 110,
                    ["Hm"] = 0.01,
                    ["Hv"] = 0.0001,
                    ["C"] = 0.1,
                    ["TAir"] = TAir
                };

                ITest test = new CriticalTemperatureTest();

                IEngineCreator engineCreator = new InternalCombustionEngineCreator();

                DefaultEngine engine = engineCreator.CreateEngine(payload);

                DefaultStand testStand = new CriticalTempStand(engine, test);
                try
                {
                    testStand.RunTest();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Цифры нормальные введи");
            }
            
        }
    }
}
