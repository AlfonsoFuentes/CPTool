using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPTool.Persistence.Generic
{ //
  // Resumen:
  //     This holds an error registered in the StatusGeneric.IStatusGeneric Errors collection
    public struct ErrorGeneric
    {
        //
        // Resumen:
        //     If there are multiple headers this separator is placed between them, e.g. Update>Author
        public const string HeaderSeparator = ">";

        //
        // Resumen:
        //     A Header. Can be null
        public string Header { get; private set; }

        //
        // Resumen:
        //     This is the error provided
        public ValidationResult ErrorResult { get; private set; }

        //
        // Resumen:
        //     This can be used to contain extra data to help the developer debug the error
        //     For instance, the content of an exception.
        public string DebugData { get; private set; }

        //
        // Resumen:
        //     This ctor will create an ErrorGeneric
        //
        // Parámetros:
        //   header:
        //
        //   error:
        public ErrorGeneric(string header, ValidationResult error)
        {
            this = default(ErrorGeneric);
            Header = header ?? throw new ArgumentNullException("header");
            ErrorResult = error ?? throw new ArgumentNullException("error");
        }

        internal ErrorGeneric(string prefix, ErrorGeneric existingError)
        {
            Header = (string.IsNullOrEmpty(prefix) ? existingError.Header : (string.IsNullOrEmpty(existingError.Header) ? prefix : (prefix + ">" + existingError.Header)));
            ErrorResult = existingError.ErrorResult;
            DebugData = existingError.DebugData;
        }

        //
        // Resumen:
        //     This copies the exception Message, StackTrace and any entries in the Data dictionary
        //     into the DebugData string
        //
        // Parámetros:
        //   ex:
        internal void CopyExceptionToDebugData(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(ex.Message);
            stringBuilder.Append("StackTrace:");
            stringBuilder.AppendLine(ex.StackTrace);
            foreach (DictionaryEntry datum in ex.Data)
            {
                stringBuilder.AppendLine($"Data: {datum.Key}\t{datum.Value}");
            }

            DebugData = stringBuilder.ToString();
        }

        //
        // Resumen:
        //     A human-readable error display
        public override string ToString()
        {
            return (string.IsNullOrEmpty(Header) ? "" : (Header + ": ")) + ErrorResult.ToString();
        }
    }
}
