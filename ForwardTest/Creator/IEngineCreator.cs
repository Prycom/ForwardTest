using ForwardTest.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForwardTest.Creator
{
    public interface IEngineCreator
    {
        public DefaultEngine CreateEngine(Dictionary<string, object> payload);
    }
}
