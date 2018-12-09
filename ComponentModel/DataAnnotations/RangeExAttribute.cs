/* ------------------------------------------------------------------------- *
thZero.NetCore.Library.Data.Annotations
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

namespace System.ComponentModel.DataAnnotations
{
	public abstract class RangeExAttribute : RangeAttribute //, IRangeAttribute
	{
		private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(RangeExAttribute));

		protected RangeExAttribute(double minimum, double maximum) : base(minimum, maximum)
		{
			ErrorMessageResourceName = "ValidatorRange";
		}

		protected RangeExAttribute(int minimum, int maximum)
			: base(minimum, maximum)
		{
			ErrorMessageResourceName = "ValidatorRange";
		}

		protected RangeExAttribute(Type type, string minimum, string maximum)
			: base(type, minimum, maximum)
		{
			ErrorMessageResourceName = "ValidatorRange";
		}

		#region Public Methods
		public override string FormatErrorMessage(string name)
		{
			const string Declaration = "FormatErrorMessage";

			try
			{
				if (ErrorMessageResourceType != null)
					return base.FormatErrorMessage(name);
				if (string.IsNullOrEmpty(ErrorMessageResourceName))
					return base.FormatErrorMessage(name);

				string resourceName = ErrorMessageResourceName;
				if (!resourceName.StartsWith("Validator"))
					resourceName = string.Concat("Validator", resourceName);

				return thZero.Utilities.Localization.Validation(resourceName, name, Minimum.ToString(), Maximum.ToString());
			}
			catch (Exception ex)
			{
				log.Error(Declaration, ex);
				throw;
			}
		}
		#endregion

		#region Public Properties
		//public virtual Type RangeAdapterType { get { return typeof(RangeAdapter); } }
		#endregion
	}
}