using FluentValidation;

namespace BlogApp.API.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {

        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name bos ola bilmez")
                .NotNull()
                .WithMessage("Name null ola bilmaz")
                .MaximumLength(20)
                .WithMessage("name uzunlugu max 20 ola biler")
                .MinimumLength(3)
                .WithMessage("name uzunlugu min 3 ola biler");

        }
    }

}
