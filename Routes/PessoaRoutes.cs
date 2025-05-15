using CrudAPI_CSharp.Models;

namespace CrudAPI_CSharp.Routes;

public static class PessoaRoutes
{
    public static void PessoaRotas(this WebApplication app)
    {
        app.MapGet("/api/pessoas", PessoaModel.GetAll);
        app.MapGet("/api/pessoas/{id:guid}", PessoaModel.GetById);
        app.MapPost("/api/pessoas", PessoaModel.Create);
        app.MapPut("/api/pessoas/{id:guid}", PessoaModel.Update);
        app.MapDelete("/api/pessoas/{id:guid}", PessoaModel.Delete);
    }
}