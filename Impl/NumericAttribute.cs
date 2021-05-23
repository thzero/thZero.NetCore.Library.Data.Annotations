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
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class NumericAttribute : ValidationExAttribute //, IClientValidatable
    {
        private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(typeof(NumericAttribute));

        public NumericAttribute() : base(DefaultErrorMessage)
        {
            ErrorMessageResourceName = "ValidatorNumeric";
        }

        #region Public Methods
        public override string FormatErrorMessage(string name)
        {
            const string Declaration = "FormatErrorMessage";

            try
            {
                return string.Format(base.FormatErrorMessage(name), name, NumericType.ToString());
            }
            catch (Exception ex)
            {
                log.Error(Declaration, ex);
                throw;
            }
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //	 var rule = new ModelClientValidationRule();
        //	 rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
        //	 rule.ValidationParameters.Add("numerictype", NumericType.ToString());

        //	 if ((NumericType == NumericType.All) || (NumericType == NumericType.Double))
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Double.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Double.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.Byte)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Byte.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Byte.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.Decimal)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Decimal.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Decimal.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.Int16)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Int16.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Int16.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.Int32)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Int32.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Int32.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.Int64)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Int64.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Int64.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.SByte)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", SByte.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", SByte.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.Single)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", Single.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", Single.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.UInt16)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", UInt16.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", UInt16.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.UInt32)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", UInt32.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", UInt32.MinValue);
        //	 }
        //	 else if (NumericType == NumericType.UInt64)
        //	 {
        //			rule.ValidationParameters.Add("numericmax", UInt64.MaxValue);
        //			rule.ValidationParameters.Add("numericmin", UInt64.MinValue);
        //	 }

        //	 rule.ValidationType = "numeric";
        //	 yield return rule;
        //}

        public override bool IsValid(object value)
        {
            const string Declaration = "GetClientValidationRules";

            try
            {
                if (value == null)
                    return true;

                bool valid = false;

                try
                {
                    if ((NumericType == NumericType.All) || (NumericType == NumericType.Double))
                    {
                        Convert.ToDouble(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.Byte)
                    {
                        Convert.ToByte(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.Decimal)
                    {
                        Convert.ToDecimal(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.Int16)
                    {
                        Convert.ToInt16(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.Int32)
                    {
                        Convert.ToInt32(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.Int64)
                    {
                        Convert.ToInt64(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.SByte)
                    {
                        Convert.ToSByte(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.Single)
                    {
                        Convert.ToSingle(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.UInt16)
                    {
                        Convert.ToUInt16(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.UInt32)
                    {
                        Convert.ToUInt32(value);
                        valid |= true;
                    }
                    else if (NumericType == NumericType.UInt64)
                    {
                        Convert.ToUInt64(value);
                        valid |= true;
                    }
                }
                catch (FormatException)
                {
                }
                catch (InvalidCastException)
                {
                }

                return valid;
            }
            catch (Exception ex)
            {
                log.Error(Declaration, ex);
                throw;
            }
        }
        #endregion

        #region Public Properties
        public NumericType NumericType { get; set; } = NumericType.All;
        #endregion

        #region Constants
        private const string DefaultErrorMessage = "The {0} field must be of type '{1}'.";
        #endregion
    }

    public enum NumericType
    {
        All,
        Byte,
        Decimal,
        Double,
        Int16,
        Int32,
        Int64,
        SByte,
        Single,
        UInt16,
        UInt32,
        UInt64
    }
}