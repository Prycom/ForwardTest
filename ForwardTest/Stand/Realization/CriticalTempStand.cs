using ForwardTest.Engine;
using ForwardTest.Test;

namespace ForwardTest.Stand.Realization
{
    class CriticalTempStand : DefaultStand
    {
        public CriticalTempStand(DefaultEngine engine, ITest test) : base(engine, test)
        {
            _engine.OnEngineRun += _test.TestData;
        }

        public override void RunTest()
        {
            _engine.Run();
        }
    }
}
