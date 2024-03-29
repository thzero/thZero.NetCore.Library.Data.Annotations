﻿///* ------------------------------------------------------------------------- *
//thZero.NetCore.Library.Data.Annotations
//Copyright (C) 2016-2019 thZero.com

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

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;

//using thZero;

//namespace System.ComponentModel.DataAnnotations
//{
//	public sealed class ConditionalRequiredAttribute : ValidationAttribute, IClientValidatable
//	{
//		private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(ValidationAttribute));

//		public ConditionalRequiredAttribute(string dependentProperty)
//		{
//			DependentProperty = dependentProperty;
//			ErrorMessageResourceName = "ValidatorRequired";
//		}

//		#region Public Methods
//		public override string FormatErrorMessage(string name)
//		{
//			try
//			{
//				if (ErrorMessageResourceType != null)
//					return base.FormatErrorMessage(name);
//				if (string.IsNullOrEmpty(ErrorMessageResourceName))
//					return base.FormatErrorMessage(name);

//				string resourceName = ErrorMessageResourceName;
//				if (!resourceName.StartsWith("Validator"))
//					resourceName = string.Concat("Validator", resourceName);

//				return thZero.Utilities.Localization.Validation(resourceName, name);
//			}
//			catch (Exception ex)
//			{
//				log.Error("FormatErrorMessage", ex);
//				throw;
//			}
//		}

//		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
//		{
//			var rule = new ModelClientValidationRule()
//			{
//				ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
//				ValidationType = "conditionalrequired",
//			};

//			string dependentProperty = BuildDependentPropertyId(metadata, context as ViewContext);
//			// Parameter names must be lower case
//			rule.ValidationParameters.Add("dependentproperty", dependentProperty);

//			yield return rule;
//		}

//		public override bool IsValid(object value)
//		{
//			const string Declaration = "IsValid";

//			try
//			{
//				if (value is bool)
//					return (bool)value;
//				else if (value is string)
//					return !string.IsNullOrEmpty((string)value);
//				else if (value is Guid)
//					return (Guid)value != Guid.Empty;

//				return base.IsValid(value);
//			}
//			catch (Exception ex)
//			{
//				log.Error(Declaration, ex);
//				throw;
//			}
//		}
//		#endregion

//		#region Public Properties
//		public string DependentProperty { get; set; }
//		#endregion

//		#region Protected Methods
//		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//		{
//			Enforce.AgainstNull(() => validationContext);

//			// get a reference to the property this validation depends upon
//			var containerType = validationContext.ObjectInstance.GetType();
//			var field = containerType.GetProperty(DependentProperty);

//			if (field != null)
//			{
//				// get the value of the dependent property
//				var dependentValue = field.GetValue(validationContext.ObjectInstance, null);

//				bool valid = IsValid(dependentValue);
//				if (!valid)
//					// validation failed - return an error
//					return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
//			}

//			return ValidationResult.Success;
//		}
//		#endregion

//		#region Private Methods
//		private string BuildDependentPropertyId(ModelMetadata metadata, ViewContext viewContext)
//		{
//			// build the ID of the property
//			string dependentProperty = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(DependentProperty);
//			// unfortunately this will have the name of the current field appended to the beginning,
//			// because the TemplateInfo's context has had this fieldname appended to it. Instead, we
//			// want to get the context as though it was one level higher (i.e. outside the current property,
//			// which is the containing object (our Person), and hence the same level as the dependent property.
//			var thisField = metadata.PropertyName + "_";
//			if (dependentProperty.StartsWith(thisField))
//				// strip it off again
//				dependentProperty = dependentProperty.Substring(thisField.Length);

//			return dependentProperty;
//		}
//		#endregion
//	}
//}