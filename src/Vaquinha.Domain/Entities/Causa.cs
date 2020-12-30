using System;
using FluentValidation;
using Vaquinha.Domain.Base;

namespace Vaquinha.Domain.Entities
{
    public class Causa : Entity
    {
        private Causa()
        {
        }

        public Causa(Guid id, string nome, string cidade, string estado)
        {
            Id = id;
            Nome = nome;
            Cidade = cidade;
            Estado = estado;
        }

        public string Nome { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public override bool Valido()
        {
            ValidationResult = new CausaValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CausaValidacao : AbstractValidator<Causa>
    {
        private const int MAX_LENTH_CAMPOS = 150;

        public CausaValidacao()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .MaximumLength(MAX_LENTH_CAMPOS).WithMessage("O campo Nome deve possuir no máximo 150 caracteres.");

            RuleFor(a => a.Cidade)
                .NotEmpty().WithMessage("O campo Cidade é obrigatório.")
                .MaximumLength(MAX_LENTH_CAMPOS).WithMessage("O campo Cidade deve possuir no máximo 150 caracteres.");

            RuleFor(a => a.Estado)
                .NotEmpty().WithMessage("O campo Estado é obrigatório.")
                .MaximumLength(MAX_LENTH_CAMPOS).WithMessage("O campo Estado deve possuir no máximo 150 caracteres.");
        }
    }
}