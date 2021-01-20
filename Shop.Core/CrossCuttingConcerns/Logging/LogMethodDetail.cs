using System.Collections.Generic;

namespace Shop.Core.CrossCuttingConcerns.Logging
{
    public class LogMethodDetail
    {
        public string Name { get; set; }
        public string DeclaringTypeFullName { get; set; }

        public List<LogMethodParameter> Parameters { get; set; }

        public class LogMethodParameter
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public object Value { get; set; }
        }
    }
}
