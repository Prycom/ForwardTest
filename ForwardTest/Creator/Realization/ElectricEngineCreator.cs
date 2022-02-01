using ForwardTest.Engine;
using ForwardTest.Engine.Realization;
using System.Collections.Generic;

namespace ForwardTest.Creator.Realization
{
    public class ElectricEngineCreator : IEngineCreator
    {
        public DefaultEngine CreateEngine(Dictionary<string, object> payload) => new ElectricEngine(payload);
    }
}
