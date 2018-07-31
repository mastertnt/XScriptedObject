﻿using NUnit.Framework;
using Sprache;

namespace XScriptedObject.Tests
{
    /// <summary>
    /// Global class for all tests.
    /// </summary>
    public class Global
    {
        /// <summary>
        /// Checks the integer.
        /// </summary>
        [Test]
        public static void CheckInteger()
        {
            var lInput = "42";
            var lResult = Integer.PARSER.TryParse(lInput);
            Assert.AreEqual(42, lResult.Value.Value);
        }

        /// <summary>
        /// Checks the real.
        /// </summary>
        [Test]
        public static void CheckReal()
        {
            var lInput = "42.34";
            var lResult = Real.PARSER.TryParse(lInput);
            Assert.AreEqual(42.34, (double)lResult.Value.Value, 0.001);
        }

        /// <summary>
        /// Checks the false boolean.
        /// </summary>
        [Test]
        public static void CheckFalseBoolean()
        {
            var lInput = "false";
            var lResult = Boolean.PARSER.TryParse(lInput);
            Assert.AreEqual(false, lResult.Value.Value);
        }

        /// <summary>
        /// Checks the true boolean.
        /// </summary>
        [Test]
        public static void CheckTrueBoolean()
        {
            var lInput = "true";
            var lResult = Boolean.PARSER.TryParse(lInput);
            Assert.AreEqual(true, lResult.Value.Value);
        }

        /// <summary>
        /// Checks the quoted string.
        /// </summary>
        [Test]
        public static void CheckQuotedString()
        {
            var lInput = "\"This is ok\"";
            var lResult = QuotedString.PARSER.TryParse(lInput);
            Assert.AreEqual("This is ok", lResult.Value.Value);
        }

        /// <summary>
        /// Checks the quoted string2.
        /// </summary>
        [Test]
        public static void CheckQuotedString2()
        {
            var lInput = "\"This ` is ok\"";
            var lResult = QuotedString.PARSER.TryParse(lInput);
            Assert.AreEqual("This ` is ok", lResult.Value.Value);
        }

        /// <summary>
        /// Checks the quoted string with missing close.
        /// </summary>
        [Test]
        public static void CheckQuotedStringWithMissingClose()
        {
            var lInput = "\"This is ok";
            var lResult = QuotedString.PARSER.TryParse(lInput);
            Assert.AreEqual(false, lResult.WasSuccessful);
        }

        /// <summary>
        /// Checks the simple function.
        /// </summary>
        [Test]
        public static void CheckSimpleFunction()
        {
            var lInput = "myFunction()";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with bool parameter.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithBoolParameter()
        {
            var lInput = "myFunction(false)";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with quoted parameter.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithQuotedParameter()
        {
            var lInput = "myFunction(\"myWorld\")";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with integer.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithInteger()
        {
            var lInput = "myFunction(42)";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with real.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithReal()
        {
            var lInput = "myFunction(42.34)";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with two integers.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithTwoIntegers()
        {
            var lInput = "myFunction(42,42)";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with two quoted strings.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithTwoQuotedStrings()
        {
            var lInput = "myFunction(\"this is\", \" my world\")";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with two booleans.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithTwoBooleans()
        {
            var lInput = "WriteArgs2(false,true);";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("WriteArgs2", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with two reals.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithTwoReals()
        {
            var lInput = "myFunction(42.34, 56.78)";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with four mixed.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithFourMixed()
        {
            var lInput = "myFunction(42.34, false, 42, \"this is my world\")";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual("myFunction", lResult.Value.Identifier);
        }

        /// <summary>
        /// Checks the simple function with invalid character.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithInvalidCharacter()
        {
            var lInput = "myFu;nction()";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual(false, lResult.WasSuccessful);
        }

        /// <summary>
        /// Checks the simple function with invalid space.
        /// </summary>
        [Test]
        public static void CheckSimpleFunctionWithInvalidSpace()
        {
            var lInput = "myFu nction()";
            var lResult = Function.PARSER.TryParse(lInput);
            Assert.AreEqual(false, lResult.WasSuccessful);
        }

        /// <summary>
        /// Checks the script on function.
        /// </summary>
        [Test]
        public static void CheckScriptOnFunction()
        {
            var lInput = "myFunction(42.34, false, 42, \"this is my world\");";
            var lResult = Script.PARSER.TryParse(lInput);
            Assert.AreEqual(true, lResult.WasSuccessful);
        }

        /// <summary>
        /// Checks the script.
        /// </summary>
        [Test]
        public static void CheckScript()
        {
            var lInput = "myFunction(42.34, false, 42, \"this is my world\");myFunction2(42,42);";
            var lResult = Script.PARSER.TryParse(lInput);
            Assert.AreEqual(true, lResult.WasSuccessful);
        }
    }
}
