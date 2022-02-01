using ForwardTest.Engine;
using ForwardTest.Test;

namespace ForwardTest.Stand
{
    public abstract class DefaultStand
    {
        protected DefaultEngine _engine;
        protected ITest _test;

        public DefaultStand(DefaultEngine engine, ITest test)
        {
            _engine = engine;
            _test = test;
        }

        public abstract void RunTest(); 
    }
}
