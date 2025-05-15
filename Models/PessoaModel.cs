namespace CrudAPI_CSharp.Models;

public class PessoaModel(string nome)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;

    private static readonly List<PessoaModel> Pessoas = new();
    
    public static IResult GetAll() => Results.Ok(Pessoas);
    
    public static IResult GetById(Guid id)
    {
        var pessoa = Pessoas.FirstOrDefault(p => p.Id == id);
        return pessoa is not null ? Results.Ok(pessoa) : Results.NotFound();
    }
    
    public static IResult Create(string nome)
    {
        var pessoa = new PessoaModel(nome);
        Pessoas.Add(pessoa);
        return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
    }
    
    public static IResult Update(Guid id, string nomeAtualizado)
    {
        var pessoa = Pessoas.FirstOrDefault(p => p.Id == id);
        if (pessoa is null) return Results.NotFound();
        pessoa.Nome = nomeAtualizado;
        return Results.NoContent();
    }
    
    public static IResult Delete(Guid id)
    {
        var pessoa = Pessoas.FirstOrDefault(p => p.Id == id);
        if (pessoa is null) return Results.NotFound();

        Pessoas.Remove(pessoa);
        return Results.NoContent();
    }
}