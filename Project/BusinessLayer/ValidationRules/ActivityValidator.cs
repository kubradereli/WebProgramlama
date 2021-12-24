using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.ActivityTitle).NotEmpty().WithMessage("Etkinlik başlığını boş geçemezsiniz.");
            RuleFor(x => x.ActivityContent).NotEmpty().WithMessage("Etkinlik içeriğini boş geçemezsiniz.");
            RuleFor(x => x.ActivityImage).NotEmpty().WithMessage("Etkinlik görselini boş geçemezsiniz.");
            RuleFor(x => x.ActivityTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden az veri girişi yapın.");
            RuleFor(x => x.ActivityTitle).MinimumLength(5).WithMessage("Lütfen 4 karakterden fazla veri girişi yapın.");
        }
    }
}