using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ForwardTest.Functional
{
    public abstract class Exportable
    {
        protected Dictionary<string, object> ExportData<T>() where T : class
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var fieldValues = GetType().GetFields(flags).Select(field => field.GetValue(this)).ToList();
            var fieldNames = typeof(T).GetFields(flags).Select(field => field.Name).ToList();
            
            Dictionary<string, object> _data = new Dictionary<string, object>();
            
            for (int i = 0; i < fieldNames.Count; i++)
                _data.Add(fieldNames[i], fieldValues[i]);

            return _data;
        }
    }
}
