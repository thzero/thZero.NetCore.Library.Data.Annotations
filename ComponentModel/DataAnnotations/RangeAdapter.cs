///* ------------------------------------------------------------------------- *
//thZero.NetCore.Library.Data.Annotations
//Copyright (C) 2016-2018 thZero.com

//<development [at] thzero [dot] com>

//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at

//	http://www.apache.org/licenses/LICENSE-2.0

//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.
// * ------------------------------------------------------------------------- */

//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;

//namespace System.ComponentModel.DataAnnotations
//{
//	public class RangeAdapter : RangeAdapterBase<RangeAttribute>
//	{
//		public RangeAdapter(ModelMetadata metadata, ControllerContext context, RangeAttribute attribute)
//			: base(metadata, context, attribute) { }
//	}

//	public class RangeAdapterBase<T> : DataAnnotationsModelValidator<T> where T : RangeAttribute
//	{
//		public RangeAdapterBase(ModelMetadata metadata, ControllerContext context, T attribute)
//			: base(metadata, context, attribute) { }

//		#region Public Methods
//		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
//		{
//			var rule = new ModelClientValidationRangeRule(Attribute.ErrorMessage, Attribute.Minimum, Attribute.Maximum);

//			return new[] { rule };
//		}
//		#endregion
//	}

//	public interface IRangeAttribute
//	{
//		#region Properties
//		Type RangeAdapterType { get; }
//		#endregion
//	}

//	public interface IIgnoreRangeAdapter
//	{
//	}
//}