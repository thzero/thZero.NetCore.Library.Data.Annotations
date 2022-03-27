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

using System.Globalization;

using thZero;

namespace System.ComponentModel.DataAnnotations
{
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class TextLengthAttribute : ValidationExAttribute
    {
        private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(TextLengthAttribute));

        public TextLengthAttribute() : base(DefaultErrorMessage)
        {
            ErrorMessageResourceName = "ValidatorNumericLength";
        }

        #region Public Methods
        public override string FormatErrorMessage(string name)
        {
            try
            {
                if (DefaultErrorMessage.EqualsIgnore(ErrorMessage))
                {
                    ErrorMessage = "The {0} field must be between {1} and {2}.";

                    if ((Maximum < int.MaxValue) && (Minimum == int.MinValue))
                        ErrorMessage = "The {0} field must be greater than and {2}.";

                    if ((Minimum > int.MinValue) && (Minimum == int.MinValue))
                        ErrorMessage = "The {0} field must be less than and {1}.";

                    return string.Format(CultureInfo.CurrentUICulture, ErrorMessage, name, Minimum.ToString(), Maximum.ToString());
                }

                return string.Format(CultureInfo.CurrentUICulture, base.FormatErrorMessage(name), name, Minimum.ToString(), Maximum.ToString());
            }
            catch (Exception ex)
            {
                log.Error("FormatErrorMessage", ex);
                throw;
            }
        }

        public override bool IsValid(object value)
        {
            try
            {
                if (value is not string)
                    return false;

                string data = value as string;
                if (string.IsNullOrEmpty(data))
                    return false;

                if (Minimum > Maximum)
                    throw new InvalidMinMaxException();

                if ((Maximum < int.MaxValue) && data.Length > Maximum)
                    return false;

                if ((Minimum > int.MinValue) && data.Length < Minimum)
                    return false;
            }
            catch (Exception ex)
            {
                log.Error("IsValid", ex);
                throw;
            }

            return true;
        }
        #endregion

        #region Public Properties
        public int Maximum { get; set; } = int.MaxValue;
        public int Minimum { get; set; } = int.MinValue;
        #endregion

        #region Constants
        private const string DefaultErrorMessage = "The {0} field must be between {1} and {2}.";
        #endregion
    }

    public class InvalidMinMaxException : Exception
    {
        public InvalidMinMaxException() : base("Invalid Min. and Max. values.")
        {
        }
    }
}