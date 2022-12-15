namespace CPTool.Persistence.Generic
{ //
    // Resumen:
    //     This is a version of StatusGeneric.IStatusGeneric that contains a result. Useful
    //     if you want to return something with the status
    //
    // Parámetros de tipo:
    //   T:
    public interface IStatusGeneric<out T> : IStatusGeneric
    {
        //
        // Resumen:
        //     This contains the return result, or if there are errors it will return default(T)
        T Result { get; }
    }

    //
    // Resumen:
    //     This is the interface for creating and returning
    public interface IStatusGeneric
    {
        //
        // Resumen:
        //     This holds the list of errors. If the collection is empty, then there were no
        //     errors
        IReadOnlyList<ErrorGeneric> Errors { get; }

        //
        // Resumen:
        //     This is true if there are no errors registered
        bool IsValid { get; }

        //
        // Resumen:
        //     This is true if any errors have been added
        bool HasErrors { get; }

        //
        // Resumen:
        //     On success this returns any message set by GenericServices, or any method that
        //     returns a status If there are errors it contains the message "Failed with NN
        //     errors"
        string Message { get; set; }

        //
        // Resumen:
        //     This allows statuses to be combined
        //
        // Parámetros:
        //   status:
        IStatusGeneric CombineStatuses(IStatusGeneric status);

        //
        // Resumen:
        //     This is a simple method to output all the errors as a single string - null if
        //     no errors Useful for feeding back all the errors in a single exception (also
        //     nice in unit testing)
        //
        // Parámetros:
        //   separator:
        //     if null then each errors is separated by Environment.NewLine, otherwise uses
        //     the separator you provide
        //
        // Devuelve:
        //     a single string with all errors separated by the 'separator' string
        string GetAllErrors(string separator = null);
    }
}
