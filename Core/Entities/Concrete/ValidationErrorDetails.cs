using FluentValidation.Results;

namespace Core.Entities.Concrete
{
    public class ValidationErrorDetails: ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}
