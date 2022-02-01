using System.Collections.Generic;

namespace ForwardTest.Test.Realization
{
    class CriticalTemperatureTest : ITest
    {
        private double _minEps = 0.0001;

        public bool TestData(Dictionary<string, object> payload)
        {
            if((double)payload["Vc"] + (double)payload["Vh"] <= _minEps)
            {//если двигатель не греется
                System.Console.WriteLine($"Перегрева не будет, примерная температура {payload["TEngine"]}");
                return false;
            }
            
            if((double)payload["TEngine"] >= (double)payload["T"])
            {//если перегрев
                System.Console.WriteLine($"Перегрев произойдёт через {payload["_timeRun"]} секунд после запуска");
                return false;
            }

            return true;
        }
    }
}
