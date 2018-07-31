using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// This class represents a real argument of a function.
    /// </summary>
    public class Real : AArgument
    {
        /// <summary>
        /// Parser for fractional part.
        /// </summary>
        public static readonly Parser<string> FRACTIONAL = 
            from lDot in Parse.String(".").Text()
            from lDigits in Parse.Digit.Many().Text()
            select lDot + lDigits;

        /// <summary>
        /// Main parser for real.
        /// </summary>
        public static readonly Parser<AArgument> PARSER =
            from lInteger in Integer.PARSER
            from lFractional in FRACTIONAL.Optional()
            select new Real(lInteger.TypedValue + (lFractional.IsDefined ? lFractional.Get() : ""));

        /// <summary>
        /// Gets the value as an object.
        /// </summary>
        public override object Value
        {
            get
            {
                if (this.IntTypedValue != null)
                {
                    return this.IntTypedValue;
                }
                return this.DoubleTypedValue;
            }
        }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        public double? DoubleTypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        public int? IntTypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The boolean value as string.</param>
        public Real(string pValue)
        {
            int lIntValue;
            if (int.TryParse(pValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lIntValue))
            {
                this.IntTypedValue = lIntValue;
            }
            else
            {
                double lValue;
                double.TryParse(pValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lValue);
                this.DoubleTypedValue = lValue;
            }
        }
    }
}
