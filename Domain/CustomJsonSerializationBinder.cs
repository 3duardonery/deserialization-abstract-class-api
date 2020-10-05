using Newtonsoft.Json.Serialization;
using System;

namespace Domain
{
    public class CustomJsonSerializationBinder : DefaultSerializationBinder
    {
        private readonly string _namespaceToTypes;

        public CustomJsonSerializationBinder(string namespaceToTypes)
        {
            _namespaceToTypes = namespaceToTypes;
        }

        public override void BindToName(
            Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.FullName.Replace(_namespaceToTypes, string.Empty).Trim('.');
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            var typeNameWithNamespace = $"{_namespaceToTypes}.{typeName}";
            return Type.GetType(typeNameWithNamespace);
        }
    }
}
