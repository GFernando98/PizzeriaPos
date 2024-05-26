using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace PosPizzeria.Framework.GenericRepository.GenericRepository;


public class SqlServerRepository : BaseRepository, IRepository<SqlServerRepository>
{
    private readonly string _connectionString;

    public SqlServerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<T> Find<T>()
    {
        var select = GenerateSelect<T>();

        return await SelectEntity<T>($"{select};");
    }

    public async Task<T> Find<T>(IDictionary<string, object> parameters)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhere(parameters);

        var dynamicParameters = ToParameters(parameters);

        return await SelectEntity<T>($"{select} {where}", dynamicParameters);
    }

    public async Task<T> Find<T>(params (string, object, RepositoryEnum)[] parameters)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhereParams(parameters);

        var dynamicParameters = ToParameters(parameters);

        return await SelectEntity<T>($"{select} {where}", dynamicParameters);
    }

    public async Task<T> FindBetween<T>(string column, (string, object) init, (string, object) end)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhereBetweenParams(column, init, end);

        var dynamicParameters = ToParameters(init, end);

        return await SelectEntity<T>($"{select} {where}", dynamicParameters);
    }

    public async Task<List<T>> FindAll<T>()
    {
        var select = GenerateSelect<T>();

        return await SelectEntities<T>($"{select};");
    }

    public async Task<List<T>> FindAll<T>(IDictionary<string, object> parameters)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhere(parameters);

        var dynamicParameters = ToParameters(parameters);

        return await SelectEntities<T>($"{select} {where};", dynamicParameters);
    }

    public async Task<List<T>> FindAll<T>(params (string, object)[] parameters)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhereParams(parameters);

        var dynamicParameters = ToParameters(parameters);

        return await SelectEntities<T>($"{select} {where};", dynamicParameters);
    }

    public async Task<List<T>> FindAll<T>(params (string, object, RepositoryEnum)[] parameters)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhereParams(parameters);

        var dynamicParameters = ToParameters(parameters);

        return await SelectEntities<T>($"{select} {where};", dynamicParameters);
    }

    public async Task<List<T>> FindAllBetween<T>(string column, (string, object) init, (string, object) end)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhereBetweenParams(column, init, end);

        var dynamicParameters = ToParameters(init, end);

        return await SelectEntities<T>($"{select} {where}", dynamicParameters);
    }

    public async Task<List<T>> FindAllIn<T>((string, object[]) inside)
    {
        throw new NotImplementedException();
    }

    public async Task<T> Find<T>(params (string, object)[] parameters)
    {
        var select = GenerateSelect<T>();

        var where = GenerateWhereParams(parameters);

        var dynamicParameters = ToParameters(parameters);

        return await SelectEntity<T>($"{select} {where}", dynamicParameters);
    }

    public async Task<int> Insert<T>(T entity)
    {
        var insert = GenerateInsert<T>(DatabaseEnum.SQLServer);

        var dictionary = ToDictionary(entity);

        var dynamicParameters = ToParameters(dictionary);

        return await ExecuteInsertUpdate(insert, dynamicParameters, true);
    }

    public async Task<int> Update<T>(T entity, int id)
    {
        var update = GenerateUpdate<T>();

        var parameters = ToDictionary(entity);

        parameters["Id"] = id;

        var where = GenerateWhereUpdate();

        var dynamicParameters = ToParameters(parameters);

        await ExecuteInsertUpdate($"{update} {where}", dynamicParameters, false);

        return id;
    }

    public async Task<T> StoreProcedure<T>(string sp, params (string, object)[] parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> StoreProcedureList<T>(string sp, params (string, object)[] parameters)
    {
        throw new NotImplementedException();
    }

    private async Task<T> SelectEntity<T>(string query)
    {
        using (var command = new SqlConnection(_connectionString))
        {
            var select = await command.QueryAsync<T>(query);
            return select.FirstOrDefault();
        }
    }

    private async Task<List<T>> SelectEntities<T>(string query)
    {
        using (var command = new SqlConnection(_connectionString))
        {
            var select = await command.QueryAsync<T>(query);
            return select.ToList();
        }
    }

    private async Task<T> SelectEntity<T>(string query, DynamicParameters parameters)
    {
        using (var command = new SqlConnection(_connectionString))
        {
            var select = await command.QueryAsync<T>(query, parameters);
            return select.FirstOrDefault();
        }
    }

    private async Task<List<T>> SelectEntities<T>(string query, DynamicParameters parameters)
    {
        using (var command = new SqlConnection(_connectionString))
        {
            var select = await command.QueryAsync<T>(query, parameters);
            return select.ToList();
        }
    }

    private async Task<int> ExecuteInsertUpdate(string query, DynamicParameters parameters, bool insert)
    {
        using (var command = new SqlConnection(_connectionString))
        {
            return insert
                ? await command.QuerySingleAsync<int>(query, parameters)
                : await command.ExecuteAsync(query, parameters);
        }
    }

    public async Task<int> Delete<T>(int id)
    {
        var delete = GenerateDelete<T>();

        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);

        return await ExecuteInsertUpdate(delete, dynamicParameters, false);
    }

    private string GenerateDelete<T>()
    {
        var tableName = GetTableName<T>();

        return $"DELETE FROM {tableName} WHERE Id = @Id";
    }

    protected string GetTableName<T>()
    {
        return typeof(T).Name;
    }
}