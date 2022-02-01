using ForwardTest.Engine;
using ForwardTest.Engine.Realization;
using System;
using System.Collections.Generic;

namespace ForwardTest.Creator.Realization
{
    public class InternalCombustionEngineCreator : IEngineCreator
    {
        public DefaultEngine CreateEngine(Dictionary<string, object> payload) => new InternalCombustionEngine(payload);
    }
}
