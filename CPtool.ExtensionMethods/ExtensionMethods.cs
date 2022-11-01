using Flee.PublicTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPtool.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static bool ParserInitialized { get; set; } = false;
        public static ExpressionContext? ExpContext;
        static (double value, string expres, bool validdouble) EvaluateTextToDouble(this string str)
        {
            double argresult = new double();
            if (str == "" || str == null) return (0, "", false);
            if (double.TryParse(str, out argresult))
            {
                return (double.Parse(str), "", true);
            }


            return (0, str, false);
        }
        public static double ToDouble(this string str)
        {
            double argresult = new double();
            if (str == "" || str == null) return 0;
            if (double.TryParse(str, out argresult))
            {
                return double.Parse(str);
            }
            else
            {
                if (!ParserInitialized)
                    InitializeExpressionParser();
                try
                {
                    var Expr = ExpContext!.CompileGeneric<double>(str);
                    var result = Expr.Evaluate();
                    return result;
                }
                catch (Exception ex)
                {
                    var exx = new Exception("Error parsing the math expression '" + str + "'. Make sure to use the dot as the decimal separator for numbers in math expressions, and refrain from using thousands separators to avoid parsing errors.", ex);
                }

            }
            return 0;
        }
        public static int ToInt(this string str)
        {
            int argresult = new int();
            if (str == "" || str == null) return 0;
            if (int.TryParse(str, out argresult))
            {
                return int.Parse(str);
            }
            else
            {
                var lstacaracter = EvaluateTextToDouble(str.Last().ToString());
                if (lstacaracter.validdouble)
                {
                    if (!ParserInitialized)
                        InitializeExpressionParser();
                    try
                    {
                        var Expr = ExpContext.CompileGeneric<int>(str);
                        var result = Expr.Evaluate();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        var exx = new Exception("Error parsing the math expression '" + str + "'. Make sure to use the dot as the decimal separator for numbers in math expressions, and refrain from using thousands separators to avoid parsing errors.", ex);
                    }
                }

            }
            return 0;
        }
        public static float ToFloat(this string str)
        {
            float argresult = new float();
            if (str == "" || str == null) return 0;
            if (float.TryParse(str, out argresult))
            {
                return float.Parse(str);
            }
            else
            {
                var lstacaracter = EvaluateTextToDouble(str.Last().ToString());
                if (lstacaracter.validdouble)
                {
                    if (!ParserInitialized)
                        InitializeExpressionParser();
                    try
                    {
                        var Expr = ExpContext.CompileGeneric<float>(str);
                        var result = Expr.Evaluate();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        var exx = new Exception("Error parsing the math expression '" + str + "'. Make sure to use the dot as the decimal separator for numbers in math expressions, and refrain from using thousands separators to avoid parsing errors.", ex);
                    }
                }

            }
            return 0;
        }
        public static decimal ToDecimal(this string str)
        {
            decimal argresult = new decimal();
            if (str == "" || str == null) return 0;
            if (decimal.TryParse(str, out argresult))
            {
                return decimal.Parse(str);
            }
            else
            {
                var lstacaracter = EvaluateTextToDouble(str.Last().ToString());
                if (lstacaracter.validdouble)
                {
                    if (!ParserInitialized)
                        InitializeExpressionParser();
                    try
                    {
                        var Expr = ExpContext.CompileGeneric<decimal>(str);
                        var result = Expr.Evaluate();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        var exx = new Exception("Error parsing the math expression '" + str + "'. Make sure to use the dot as the decimal separator for numbers in math expressions, and refrain from using thousands separators to avoid parsing errors.", ex);
                    }
                }

            }
            return 0;
        }
        public static void InitializeExpressionParser()
        {
            ExpContext = new ExpressionContext();
            ExpContext.Imports.AddType(typeof(Math));
            ExpContext.Variables.Clear();
            ExpContext.Options.ParseCulture = System.Globalization.CultureInfo.InvariantCulture;
            ParserInitialized = true;
        }
    }
}
