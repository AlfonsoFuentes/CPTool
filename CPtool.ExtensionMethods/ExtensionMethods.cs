using System.Globalization;
using System.Text;
using Flee.PublicTypes;
namespace CPtool.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static bool ParserInitialized { get; set; } = false;
        public static ExpressionContext ExpContext = null!;
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
            var lastcaracter = str[str.Length - 1];
            if (double.TryParse(str, out argresult))
            {
                return double.Parse(str);
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
                        var Expr = ExpContext.CompileGeneric<double>(str);
                        double result = Expr.Evaluate();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error parsing the math expression '" + str + "'. Make sure to use the dot as the decimal separator for numbers in math expressions, and refrain from using thousands separators to avoid parsing errors.", ex);
                    }
                }

            }
            return 0;
        }
        public static int ParseExpressionToInt(this string str)
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
        public static void InitializeExpressionParser()
        {
            ExpContext = new ExpressionContext();
            ExpContext.Imports.AddType(typeof(Math));
            ExpContext.Variables.Clear();
            ExpContext.Options.ParseCulture = System.Globalization.CultureInfo.InvariantCulture;
            ParserInitialized = true;
        }
        public static string DoubleRounded(this double instance)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var result = string.Empty;
            var ic = CultureInfo.InvariantCulture;
            var splits = instance.ToString(ic).Split(new[] { ic.NumberFormat.NumberDecimalSeparator }, StringSplitOptions.RemoveEmptyEntries);
            stringBuilder.Append(splits[0]);
            if (splits.Count() > 1)
            {
                string tru = splits[1];
                if (splits[1].Length > 4)
                    tru = splits[1].Remove(4);

                stringBuilder.Append('.');
                stringBuilder.Append(tru);


            }

            result = stringBuilder.ToString();
            return result;
        }
    }
}