using FluentValidation;

namespace BlogApp.API.DTOs.Category
{
    public class CreateCategoryDtos
    {
        public string Name { get; set; }

    }

    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDtos> { 
    
        public CreateCategoryValidator() {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("bos ola bilmez")
                .NotNull()
                .WithMessage("bos ola bilmez")
                .MaximumLength(30)
                .WithMessage("name uzunlugu max 20 ola biler")
                .MinimumLength(5)
                .WithMessage("name uzunlugu min5 max ola biler");

        }
    }

}
