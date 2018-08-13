///* ------------------------------------------------------------------------- *
//thZero.NetCore.Library
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

//namespace System.ComponentModel.DataAnnotations
//{
//	// Provides an adapter for the System.ComponentModel.DataAnnotations.StringLengthExAttribute attribute.
//	public class StringLengthExAttributeAdapter : DataAnnotationsModelValidator<StringLengthExAttribute>
//	{
//		public StringLengthExAttributeAdapter(ModelMetadata metadata, ControllerContext context, StringLengthExAttribute attribute)
//			: base (metadata, context, attribute)
//		{
//		}

//		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
//		{
//			var rule = new ModelClientValidationStringLengthRule(Attribute.ErrorMessage, Attribute.MinimumLength, Attribute.MaximumLength);
//			return new[] { rule };
//		}
//	}
//}