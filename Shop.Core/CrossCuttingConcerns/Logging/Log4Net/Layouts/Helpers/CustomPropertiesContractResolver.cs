using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts.Helpers
{
    /// <summary>
    /// Selects the properties to be serialized/deserialized.
    /// </summary>
    class CustomPropertiesContractResolver : DefaultContractResolver
    {
        private readonly HashSet<string> _propertyNameSet;

        /// <param name="propertyNames">The names of the properties to be serialized/deserialized.</param>
        public CustomPropertiesContractResolver(IEnumerable<string> propertyNames)
        {
            _propertyNameSet = propertyNames == null ? null : new HashSet<string>(propertyNames, StringComparer.OrdinalIgnoreCase);
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var allMembers = base.GetSerializableMembers(objectType);
            List<MemberInfo> serializableMembers = null;

            if (_propertyNameSet?.Count > 0)
                serializableMembers = allMembers.Where(x => _propertyNameSet.Contains(x.Name)).ToList();

            return serializableMembers?.Count > 0 ? serializableMembers : allMembers;
        }

    }
}
