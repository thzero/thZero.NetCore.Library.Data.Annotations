/* ------------------------------------------------------------------------- *
thZero.NetCore.Library.Data.Annotations
Copyright (C) 2016-2019 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;
using System.Globalization;

namespace System.ComponentModel.DataAnnotations
{
	[Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1018:MarkAttributesWithAttributeUsage")]
	//[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class PropertiesMustMatchAttribute : ValidationExAttribute
	{
		private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(PropertiesMustMatchAttribute));

		public PropertiesMustMatchAttribute() : base(DefaultErrorMessage)
		{
			ErrorMessageResourceName = "ValidatorPropertiesMustMatch";
		}

		#region Public Methods
		public override string FormatErrorMessage(string name)
		{
			const string Declaration = "FormatErrorMessage";

			try
			{
				return string.Format(CultureInfo.CurrentUICulture, base.FormatErrorMessage(name), name, Property1, Property2);
			}
			catch (Exception ex)
			{
				log.Error(Declaration, ex);
				throw;
			}
		}

		public override bool IsValid(object value)
		{
			const string Declaration = "IsValid";

			try
			{
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
				object value1 = properties.Find(Property1, true /* ignoreCase */).GetValue(value);
				object value2 = properties.Find(Property2, true /* ignoreCase */).GetValue(value);
				return Object.Equals(value1, value2);
			}
			catch (Exception ex)
			{
				log.Error(Declaration, ex);
				throw;
			}
		}
		#endregion

		#region Public Properties
		public string Property1
		{
			get;
			private set;
		}

		public string Property2
		{
			get;
			private set;
		}

        public override object TypeId => _typeId;
		#endregion

		#region Fields
		private readonly object _typeId = new object();
		#endregion

		#region Constants
		private const string DefaultErrorMessage = "'{0}' and '{1}' fields do not match.";
		#endregion
	}
}