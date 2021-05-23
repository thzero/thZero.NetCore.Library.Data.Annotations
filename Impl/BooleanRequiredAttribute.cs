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

namespace System.ComponentModel.DataAnnotations
{
    public sealed class BooleanRequiredAttribute : ValidationExAttribute
    {
        private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(BooleanRequiredAttribute));

        public BooleanRequiredAttribute(string errorMessage) : base(errorMessage)
        {
            ErrorMessageResourceName = "ValidatorBooleanRequired";
        }

        #region Public Methods
        public override bool IsValid(object value)
        {
            const string Declaration = "GetClientValidationRules";

            try
            {
                return (value != null) && (bool)value;
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