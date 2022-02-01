using System;
using System.Collections.Generic;
using System.Reflection;

namespace ForwardTest.Engine.Realization
{
    public class ElectricEngine : DefaultEngine
    {
        protected override List<FieldInfo> Fields { get => throw new NotImplementedException(); }
        public ElectricEngine(Dictionary<string, object> payload) : base(payload){ }

        public override void Run()
        {
            //Do something
        }
        public override Dictionary<string, object> ExportData() => ExportData<ElectricEngine>();

    }
}
