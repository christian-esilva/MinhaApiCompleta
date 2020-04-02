using FluentValidation;
using MinhaApp.Negocios.Entidades.Validacoes.Documentos;
using MinhaApp.Negocios.Enums;

namespace MinhaApp.Negocios.Entidades.Validacoes
{
    public class FornecedorValidacao : AbstractValidator<Fornecedor>
    {
        public FornecedorValidacao()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == ETipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi preenchido {PropertyValue}.");

                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento preenchido é inválido.");
            });

            When(f => f.TipoFornecedor == ETipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento preenchido é inválido.");
            });
        }
    }
}
