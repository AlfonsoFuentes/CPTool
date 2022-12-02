namespace CPToolRadzen.Templates
{
    public static class UISettings
    {
        public static int LabelColumn { get; set; } = 4;
      
        public static int UnitValueColumn { get; set; } = 4;
        public static int UnitColumn { get; set; } = ValueColumn- UnitValueColumn;
        public static int ValueColumn { get; set; } = 8 ;

        public static string RowRem { get; set; } = "margin-bottom: 0.2rem";
        public static string ColClassLabel { get; set; } = $"col-md-{LabelColumn}";
        public static string ColClassValue { get; set; } = $"col-md-{ValueColumn}";
        public static string ColClassUnitValue { get; set; } = $"col-md-{UnitValueColumn}";
        public static string ColClassUnit { get; set; } = $"col-md-{UnitColumn}";

       
    }
}
