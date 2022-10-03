


namespace CPTool.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

       

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validatorresult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validatorresult.SelectMany(r => r.Errors).Where(y => y != null).ToList();

                if (failures.Count > 0)
                {
                    throw new CPTool.Application.Exceptions.ValidationException(failures);
                }
            }
            return await next();
        }
    }


}
