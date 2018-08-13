/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2018 thZero.com

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
	public sealed class PhoneExAttribute : ValidationAttribute
	{
		private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(PhoneExAttribute));

		public PhoneExAttribute()
			: base()
		{
			ErrorMessageResourceName = "ValidatorPhone";
			_attribute = new PhoneAttribute();
		}

		#region Public Methods
		public override string FormatErrorMessage(string name)
		{
			try
			{
				if (ErrorMessageResourceType != null)
					return base.FormatErrorMessage(name);
				if (string.IsNullOrEmpty(ErrorMessageResourceName))
					return base.FormatErrorMessage(name);

				string resourceName = ErrorMessageResourceName;
				if (!resourceName.StartsWith("Validator"))
					resourceName = string.Concat("Validator", resourceName);

				return thZero.Utilities.Localization.Validation(resourceName, name);
			}
			catch (Exception ex)
			{
				log.Error("FormatErrorMessage", ex);
				throw;
			}
		}

		public override bool IsValid(object value)
		{
			return _attribute.IsValid(value);
		}
		#endregion

		#region Fields
		private PhoneAttribute _attribute;
		#endregion
	}
}