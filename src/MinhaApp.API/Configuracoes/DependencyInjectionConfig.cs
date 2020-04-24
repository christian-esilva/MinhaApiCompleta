using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MinhaApp.API.Extensoes;
using MinhaApp.Infraestrutura.Contexto;
using MinhaApp.Infraestrutura.Repositorios;
using MinhaApp.Negocios.Interfaces;
using MinhaApp.Negocios.Notificacoes;
using MinhaApp.Negocios.Servicos;
using Swashbuckle.AspNetCore.SwaggerGen;

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
