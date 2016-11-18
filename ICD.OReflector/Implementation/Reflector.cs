using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ICD.OReflector.Implementation
{
    public class Reflector : BaseReflector
    {
        private ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>> _constructorsDictionary = new ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>>();
		private ConcurrentDictionary<bool, ConcurrentDictionary<Type, IEnumerable<Attribute>>> _typeCustomAttributesDictionary = new ConcurrentDictionary<bool, ConcurrentDictionary<Type, IEnumerable<Attribute>>>();
		private ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> _typePropertiesDictionary = new ConcurrentDictionary<Type, IEnumerable<PropertyInfo>>();
        private ConcurrentDictionary<Type, IEnumerable<EventInfo>> _typeEventsDictionary = new ConcurrentDictionary<Type, IEnumerable<EventInfo>>();
        private ConcurrentDictionary<Type, IEnumerable<MethodInfo>> _typeMethodsDictionary = new ConcurrentDictionary<Type, IEnumerable<MethodInfo>>();
        private ConcurrentDictionary<Type, IEnumerable<FieldInfo>> _typeFieldsDictionary = new ConcurrentDictionary<Type, IEnumerable<FieldInfo>>();
        private ConcurrentDictionary<IntPointerPair, IEnumerable<Attribute>> _memberCustomAttributesDictionary = new ConcurrentDictionary<IntPointerPair, IEnumerable<Attribute>>();
		
        public override IEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type == null ? base.GetConstructors(null) : _constructorsDictionary.GetOrAdd(type, base.GetConstructors(type));
        }

		public override IEnumerable<Attribute> GetCustomAttributes(Type type, bool inherit = false)
		{
			return type == null
				? base.GetCustomAttributes(null, inherit)
				: _typeCustomAttributesDictionary.GetOrAdd(inherit,
						new ConcurrentDictionary<Type, IEnumerable<Attribute>>(new List<KeyValuePair<Type, IEnumerable<Attribute>>>()
						{
							new KeyValuePair<Type, IEnumerable<Attribute>>(type,  base.GetCustomAttributes(type, inherit))
						})).GetOrAdd(type, default(IEnumerable<Attribute>));
		}

		public override IEnumerable<T> GetCustomAttributes<T>(Type type, bool inherit = false)
		{
			var customAttributes = GetCustomAttributes(type, inherit);

			return customAttributes?.Where(item => item is T).ToList().ConvertAll(item => item as T) ?? Enumerable.Empty<T>();
		}

		public override IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return type == null ? base.GetProperties(null) : _typePropertiesDictionary.GetOrAdd(type, base.GetProperties(type));
        }

        public override IEnumerable<EventInfo> GetEvents(Type type)
        {
            return type == null ? base.GetEvents(null) : _typeEventsDictionary.GetOrAdd(type, base.GetEvents(type));
        }

        public override IEnumerable<MethodInfo> GetMethods(Type type)
        {
            return type == null ? base.GetMethods(null) : _typeMethodsDictionary.GetOrAdd(type, base.GetMethods(type));
        }

        public override IEnumerable<FieldInfo> GetFields(Type type)
        {
            return type == null ? base.GetFields(null) : _typeFieldsDictionary.GetOrAdd(type, base.GetFields(type));
        }

        public override IEnumerable<Attribute> GetCustomAttributes(MemberInfo member)
        {
            return member == null ? base.GetCustomAttributes((MemberInfo)null) : _memberCustomAttributesDictionary.GetOrAdd(new IntPointerPair() {first = member.DeclaringType.TypeHandle.Value, second = member.GetType().TypeHandle.Value}, base.GetCustomAttributes(member));
        }

		public override IEnumerable<T> GetCustomAttributes<T>(MemberInfo member)
		{
			var customAttributes = GetCustomAttributes(member);

			return customAttributes?.Where(item => item is T).ToList().ConvertAll(item => item as T) ?? Enumerable.Empty<T>();
		}
	}
}
