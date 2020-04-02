using FluentValidation;
using FluentValidation.Results;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using MinhaApp.Negocios.Notificacoes;

namespace MinhaApp.Negocios.Servicos
{
    public abstract class BaseServico
    {
        private readonly INotificador _notificador;

        public BaseServico(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Manipular(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entidade
        {
            var validar = validacao.Validate(entidade);

            if(validar.IsValid) return true;

            Notificar(validar);
            return false;
        }
    }
}
