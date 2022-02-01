using ForwardTest.Functional;
using System.Collections.Generic;
using System.Reflection;

namespace ForwardTest.Engine
{
    public abstract class DefaultEngine : Exportable
    {
        public delegate bool TestResult(Dictionary<string, object> payload);
        public event TestResult OnEngineRun;
        protected abstract List<FieldInfo> Fields { get; }

        public DefaultEngine(Dictionary<string, object> payload)
        {
            foreach (var field in Fields)
            {
                object value;
                if (payload.TryGetValue(field.Name, out value))
                    field.SetValue(this, value);
            }
        }

        public abstract void Run();
        public abstract Dictionary<string, object> ExportData();
        protected bool ExecuteEvent(Dictionary<string, object> payload) => OnEngineRun.Invoke(payload);
    }

}
