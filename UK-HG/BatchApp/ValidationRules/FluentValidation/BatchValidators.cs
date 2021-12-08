using FluentValidation;
using BatchApp.Models;

namespace BatchApp.ValidationRules.FluentValidation
{
    public class BatchValidators : AbstractValidator<BatchModel>
    {
        public BatchValidators()
        {
            RuleFor(b => b.BatchID).NotEmpty();
            RuleFor(b => b.BusinessUnit).NotEmpty();
            RuleFor(b => b.BusinessUnit).Length(05);
            RuleFor(b => b.ACLs).IsInEnum();
            RuleFor(b => b.Atributes).IsInEnum();
            //RuleFor(b => b.Atribute).Must(list => list.Count < 5).
            //    WithMessage("The List Must Contain Fewer than 05 Atributes");
        }

    }
}
