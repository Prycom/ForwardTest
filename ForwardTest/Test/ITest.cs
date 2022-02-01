using System.Collections.Generic;

namespace ForwardTest.Test
{
    public interface ITest
    {
        public bool TestData(Dictionary<string, object> payload);
    }
}
