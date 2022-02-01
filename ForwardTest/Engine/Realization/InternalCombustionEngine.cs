using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ForwardTest.Engine.Realization
{
    public class InternalCombustionEngine : DefaultEngine
    {
        private double I; //Момент инерции
        private List<int> M; //Кусочно-линейная зависимость крутящего момента
        private List<int> V; //Cкорость вращения коленвала
        private double T; // Температура перегрева
        private double Hm; // Коэффициент зависимости скорости нагрева от крутящего момент
        private double Hv; // Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        private double C;// Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        private double TEngine; // температура двигателя
        private double TAir; // температура воздуха
        private int _index;
        private int _timeRun;
        private double Vc;
        private double Vh;

        protected override List<FieldInfo> Fields { get => typeof(InternalCombustionEngine).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).ToList(); }
        
        public InternalCombustionEngine(Dictionary<string, object> payload) : base(payload){ }

        public override void Run()
        {
            //Do something
            _index = 0;
            _timeRun = 0;
            bool _run = true;

            double v = V[_index];
            double m = M[_index];
            double a = m / I;

            while (_run)
            {
                _timeRun++;
                v += a;

                if (_index < V.Count - 1)
                {
                    if(v >= V[_index + 1])
                    {
                        _index++;
                    }
                    double betweenPoints = (v - V[_index]) / (V[_index + 1] - V[_index]);// сколько прошли между _index и _index + 1
                    m = betweenPoints * (M[_index + 1] - M[_index]) + M[_index];
                }
                else
                {
                    m = M[_index];
                }
                Vc = FindVc();
                Vh = FindVh(_index);
                TEngine += Vc + Vh;
                a = m / I;
                //event with bool
                _run = ExecuteEvent(ExportData());
            }
        }

        public override Dictionary<string, object> ExportData() => ExportData<InternalCombustionEngine>();
        private double FindVc() => C * (TAir - TEngine);
        private double FindVh(int _index) => M[_index] * Hm + Math.Pow(V[_index], 2) * Hv;
    }
}
