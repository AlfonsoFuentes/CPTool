using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPTool.Persistence.Generic
{  //
    // Resumen:
    //     This contains the error handling part of the GenericBizRunner
    public class StatusGenericHandler<T> : StatusGenericHandler, IStatusGeneric<T>, IStatusGeneric
    {
        private T _result;

        //
        // Resumen:
        //     This is the returned result
        public T Result
        {
            get
            {
                if (!base.IsValid)
                {
                    return default(T);
                }

                return _result;
            }
        }

        //
        // Resumen:
        //     This sets the result to be returned
        //
        // Parámetros:
        //   result:
        public StatusGenericHandler<T> SetResult(T result)
        {
            _result = result;
            return this;
        }

        //
        // Resumen:
        //     This adds one error to the Errors collection
        //
        // Parámetros:
        //   errorMessage:
        //     The text of the error message
        //
        //   propertyNames:
        //     optional. A list of property names that this error applies to
        public new IStatusGeneric<T> AddError(string errorMessage, params string[] propertyNames)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }

            _errors.Add(new ErrorGeneric(base.Header, new ValidationResult(errorMessage, propertyNames)));
            return this;
        }
    }

    //
    //
    // Resumen:
    //     This is the interface for the full StatusGenericHandler
    public interface IStatusGenericHandler : IStatusGeneric
    {
        //
        // Resumen:
        //     This adds one error to the Errors collection NOTE: This is virtual so that the
        //     StatusGenericHandler.Generic can override it. That allows both to return a IStatusGeneric
        //     result
        //
        // Parámetros:
        //   errorMessage:
        //     The text of the error message
        //
        //   propertyNames:
        //     optional. A list of property names that this error applies to
        IStatusGeneric AddError(string errorMessage, params string[] propertyNames);

        //
        // Resumen:
        //     This adds one error to the Errors collection and saves the exception's data to
        //     the DebugData property
        //
        // Parámetros:
        //   ex:
        //     The exception that you want to turn into a IStatusGeneric error.
        //
        //   errorMessage:
        //     The user-friendly text for the error message
        //
        //   propertyNames:
        //     optional. A list of property names that this error applies to
        IStatusGeneric AddError(Exception ex, string errorMessage, params string[] propertyNames);

        //
        // Resumen:
        //     This adds one ValidationResult to the Errors collection
        //
        // Parámetros:
        //   validationResult:
        void AddValidationResult(ValidationResult validationResult);

        //
        // Resumen:
        //     This appends a collection of ValidationResults to the Errors collection
        //
        // Parámetros:
        //   validationResults:
        void AddValidationResults(IEnumerable<ValidationResult> validationResults);
    }
    //
    // Resumen:
    //     This contains the error handling part of the GenericBizRunner
    public class StatusGenericHandler : IStatusGenericHandler, IStatusGeneric
    {
        //
        // Resumen:
        //     This is the default success message.
        public const string DefaultSuccessMessage = "Success";

        protected readonly List<ErrorGeneric> _errors = new List<ErrorGeneric>();

        private string _successMessage = "Success";

        //
        // Resumen:
        //     The header provides a prefix to any errors you add. Useful if you want to have
        //     a general prefix to all your errors e.g. a header if "MyClass" would produce
        //     error messages such as "MyClass: This is my error message."
        public string Header { get; set; }

        //
        // Resumen:
        //     This holds the list of ValidationResult errors. If the collection is empty, then
        //     there were no errors
        public IReadOnlyList<ErrorGeneric> Errors => _errors.AsReadOnly();

        //
        // Resumen:
        //     This is true if there are no errors
        public bool IsValid => !_errors.Any();

        //
        // Resumen:
        //     This is true if any errors have been added
        public bool HasErrors => _errors.Any();

        //
        // Resumen:
        //     On success this returns the message as set by the business logic, or the default
        //     messages set by the BizRunner If there are errors it contains the message "Failed
        //     with NN errors"
        public string Message
        {
            get
            {
                if (!IsValid)
                {
                    return $"Failed with {_errors.Count} error" + ((_errors.Count == 1) ? "" : "s");
                }

                return _successMessage;
            }
            set
            {
                _successMessage = value;
            }
        }

        //
        // Resumen:
        //     This creates a StatusGenericHandler, with optional header (see Header property,
        //     and CombineStatuses)
        //
        // Parámetros:
        //   header:
        public StatusGenericHandler(string header = "")
        {
            Header = header;
        }

        //
        // Resumen:
        //     This allows statuses to be combined. Copies over any errors and replaces the
        //     Message if the currect message is null If you are using Headers then it will
        //     combine the headers in any errors in combines e.g. Status1 with header "MyClass"
        //     combines Status2 which has header "MyProp" and status2 has errors. The result
        //     would be error message in status2 would be updates to start with "MyClass>MyProp:
        //     This is my error message."
        //
        // Parámetros:
        //   status:
        public IStatusGeneric CombineStatuses(IStatusGeneric status)
        {
            if (!status.IsValid)
            {
                List<ErrorGeneric> errors = _errors;
                IEnumerable<ErrorGeneric> collection;
                if (!string.IsNullOrEmpty(Header))
                {
                    collection = status.Errors.Select((ErrorGeneric x) => new ErrorGeneric(Header, x));
                }
                else
                {
                    IEnumerable<ErrorGeneric> errors2 = status.Errors;
                    collection = errors2;
                }

                errors.AddRange(collection);
            }

            if (IsValid && status.Message != "Success")
            {
                Message = status.Message;
            }

            return this;
        }

        //
        // Resumen:
        //     This is a simple method to output all the errors as a single string - returns
        //     "No errors" if no errors. Useful for feeding back all the errors in a single
        //     exception (also nice in unit testing)
        //
        // Parámetros:
        //   separator:
        //     if null then each errors is separated by Environment.NewLine, otherwise uses
        //     the separator you provide
        //
        // Devuelve:
        //     a single string with all errors separated by the 'separator' string, or "No errors"
        //     if no errors.
        public string GetAllErrors(string separator = null)
        {
            separator = separator ?? Environment.NewLine;
            if (!_errors.Any())
            {
                return "No errors";
            }

            return string.Join(separator, Errors);
        }

        //
        // Resumen:
        //     This adds one error to the Errors collection NOTE: This is virtual so that the
        //     StatusGenericHandler.Generic can override it. That allows both to return a IStatusGeneric
        //     result
        //
        // Parámetros:
        //   errorMessage:
        //     The text of the error message
        //
        //   propertyNames:
        //     optional. A list of property names that this error applies to
        public virtual IStatusGeneric AddError(string errorMessage, params string[] propertyNames)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }

            _errors.Add(new ErrorGeneric(Header, new ValidationResult(errorMessage, propertyNames)));
            return this;
        }

        //
        // Resumen:
        //     This adds one error to the Errors collection and saves the exception's data to
        //     the DebugData property
        //
        // Parámetros:
        //   ex:
        //     The exception that you want to turn into a IStatusGeneric error.
        //
        //   errorMessage:
        //     The user-friendly text for the error message
        //
        //   propertyNames:
        //     optional. A list of property names that this error applies to
        public IStatusGeneric AddError(Exception ex, string errorMessage, params string[] propertyNames)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }

            ErrorGeneric item = new ErrorGeneric(Header, new ValidationResult(errorMessage, propertyNames));
            item.CopyExceptionToDebugData(ex);
            _errors.Add(item);
            return this;
        }

        //
        // Resumen:
        //     This adds one ValidationResult to the Errors collection
        //
        // Parámetros:
        //   validationResult:
        public void AddValidationResult(ValidationResult validationResult)
        {
            _errors.Add(new ErrorGeneric(Header, validationResult));
        }

        //
        // Resumen:
        //     This appends a collection of ValidationResults to the Errors collection
        //
        // Parámetros:
        //   validationResults:
        public void AddValidationResults(IEnumerable<ValidationResult> validationResults)
        {
            _errors.AddRange(validationResults.Select((ValidationResult x) => new ErrorGeneric(Header, x)));
        }
    }
}
