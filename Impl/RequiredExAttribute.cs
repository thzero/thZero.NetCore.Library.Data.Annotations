﻿/* ------------------------------------------------------------------------- *
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

namespace System.ComponentModel.DataAnnotations
{
    public abstract class RequiredExAttribute : RequiredAttribute
    {
        private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(RequiredExAttribute));

        protected RequiredExAttribute() : base()
        {
            ErrorMessageResourceName = "ValidatorRequired";
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

                return thZero.Utilities.Localization.Validation(resourceName, name);
            }
            catch (Exception ex)
            {
                log.Error(Declaration, ex);
                throw;
            }
        }

        public override bool IsValid(object value)
        {
            const string Declaration = "GetClientValidationRules";

            try
            {
                if (value is bool boolean)
                    return boolean;
                else if (value is string @string)
                    return !string.IsNullOrEmpty(@string);
                else if (value is Guid guid)
                    return guid != Guid.Empty;

                return base.IsValid(value);
            }
            catch (Exception ex)
            {
                log.Error(Declaration, ex);
                throw;
            }
        }
        #endregion
    }
}