using FluentValidation;

namespace BlogApp.API.DTOs.Category
{
    public class UpdateCategoryDtos
    {
        public int Id { get; set; }
            public string Name { get; set; }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDtos>
    {

        public UpdateCategoryValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("bos ola bilmez")
                .NotNull()
                .WithMessage("bos ola bilmez")
                .MaximumLength(20)
                .WithMessage("name uzunlugu max 20 ola biler")
                .MinimumLength(5)
                .WithMessage("name uzunlugu min5 max ola biler");
        }
    }
}
