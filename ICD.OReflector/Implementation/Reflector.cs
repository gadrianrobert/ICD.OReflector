﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace ICD.OReflector.Implementation
{
	public class Reflector : BaseReflector
	{
		private ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>> _constructorsDictionary = new ConcurrentDictionary<Type, IEnumerable<ConstructorInfo>>();
		private ConcurrentDictionary<bool, ConcurrentDictionary<Type, IEnumerable<object>>> _typeCustomAttributesDictionary = new ConcurrentDictionary<bool, ConcurrentDictionary<Type, IEnumerable<object>>>();
		private ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> _typePropertiesDictionary = new ConcurrentDictionary<Type, IEnumerable<PropertyInfo>>();
		private ConcurrentDictionary<Type, IEnumerable<EventInfo>> _typeEventsDictionary = new ConcurrentDictionary<Type, IEnumerable<EventInfo>>();
		private ConcurrentDictionary<Type, IEnumerable<MethodInfo>> _typeMethodsDictionary = new ConcurrentDictionary<Type, IEnumerable<MethodInfo>>();
		private ConcurrentDictionary<Type, IEnumerable<FieldInfo>> _typeFieldsDictionary = new ConcurrentDictionary<Type, IEnumerable<FieldInfo>>();

		public override IEnumerable<ConstructorInfo> GetConstructors(Type type)
		{
			return type == null ? base.GetConstructors(null) : _constructorsDictionary.GetOrAdd(type, base.GetConstructors(type));
		}

		public override IEnumerable<object> GetCustomAttributes(Type type, bool inherit = false)
		{
			return type == null 
				? base.GetCustomAttributes(null, inherit) 
				: _typeCustomAttributesDictionary.GetOrAdd(inherit,
						new ConcurrentDictionary<Type, IEnumerable<object>>(new List<KeyValuePair<Type, IEnumerable<object>>>()
						{
							new KeyValuePair<Type, IEnumerable<object>>(type,  base.GetCustomAttributes(type, inherit))
						})).GetOrAdd(type, default(IEnumerable<object>));
		}

		public override T GetCustomAttribute<T>(Type type, bool inherit = false)
		{
			var customAttributes = GetCustomAttributes(type, inherit);
			return customAttributes != null ? (T)customAttributes.FirstOrDefault(item => customAttributes.First() is T) : default(T);
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
	}
}
