using FluentValidation.Results;

namespace CPTool.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException() :
            base("Errors found")
        {
            Errors = new Dictionary<string, string[]>();


        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName,
                q => q.ErrorMessage).
                ToDictionary(failuregroup => failuregroup.Key,
                failuregroup => failuregroup.ToArray());


        }
    }
}
