namespace CPTool.UnitsSystem
{
    public interface IAmount
    {
        string sValue { get; set; }
        Unit Unit { get; set; }
        List<Unit> UnitsList { get; }
        double Value { get; set; }

        Amount Abs();
        Amount Add(Amount amount);
        Unit AsUnit();
        object Clone();
        Amount ConvertedTo(string unitName);
        Amount ConvertedTo(string unitName, int decimals);
        Amount ConvertedTo(Unit unit);
        Amount ConvertedTo(Unit unit, int decimals);
        Amount DivideBy(Amount amount);
        Amount DivideBy(double dvalue);
        bool Equals(Amount amount);
        bool Equals(object obj);
        int GetHashCode();
        double GetValue(Unit unit);
        double GetValueManometric(Unit unit);
        Amount Inverse();
        Amount Multiply(Amount amount);
        Amount Multiply(double dvalue);
        Amount Negate();
        Amount Power(double power);
        void SetUnit(string unit);
        void SetUnit(Unit unit);
        void SetValue(Amount amount);
        void SetValue(double dvalue, string unitName);
        void SetValue(double dvalue, Unit unit);
        void SetValueManometric(Amount amo);
        void SetValueManometric(double value, Unit unit);
        void SetValueNoEvent(Amount amount);
        void SetValueNoEvent(double dvalue, Unit unit);
        Amount[] Split(Unit[] units, int decimals);
        string ToString();
        string ToString(IFormatProvider formatProvider);
        string ToString(string format);
        string ToString(string format, IFormatProvider formatProvider);
    }
}