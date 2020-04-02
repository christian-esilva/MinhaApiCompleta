using MinhaApp.Negocios.Notificacoes;
using System.Collections.Generic;

namespace MinhaApp.Negocios.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Manipular(Notificacao notificacao);
    }
}
