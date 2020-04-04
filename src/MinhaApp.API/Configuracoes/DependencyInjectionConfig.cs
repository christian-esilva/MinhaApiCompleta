using Microsoft.Extensions.DependencyInjection;
using MinhaApp.Infraestrutura.Contexto;
using MinhaApp.Infraestrutura.Repositorios;
using MinhaApp.Negocios.Interfaces;
using MinhaApp.Negocios.Notificacoes;
using MinhaApp.Negocios.Servicos;

namespace MinhaApp.API.Configuracoes
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContextoApp>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorServico, FornecedorServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();

            return services;
        }
    }
}
