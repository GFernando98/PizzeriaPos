

using Dapper;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PosPizzeria.Framework.GenericRepository.GenericRepository;

public class BaseRepository
{
    public List<ValidationResult> ValidationResults { get; set; }

    public bool Validate<T>(T obj)
    {
        ValidationResults = new List<ValidationResult>();

        var validate = Validator.TryValidateObject(obj, new ValidationContext(obj), ValidationResults, true);

        return validate;
    }

    public DynamicParameters ToParameters(IDictionary<string, object> dictionary)
    {
        return new DynamicParameters(dictionary);
    }

    public DynamicParameters ToParameters(params (string, object)[] parameters)
    {
        var param = new DynamicParameters();

        foreach (var parameter in parameters)
            param.Add(parameter.Item1, parameter.Item2);

        return param;
    }

    public DynamicParameters ToParameters(params (string, object[])[] parameters)
    {
        var param = new DynamicParameters();

        foreach (var parameter in parameters)
            param.Add(parameter.Item1, parameter.Item2);

        return param;
    }

    public DynamicParameters ToParameters(params (string, object, RepositoryEnum)[] parameters)
    {
        var param = new DynamicParameters();

        foreach (var parameter in parameters)
            param.Add(parameter.Item1, parameter.Item2);

        return param;
    }

    public DynamicParameters ToParameters((string, object) init, (string, object) end)
    {
        var param = new DynamicParameters();

        param.Add(init.Item1, init.Item2);
        param.Add(end.Item1, end.Item2);

        return param;
    }

    public Dictionary<string, object>? ToDictionary(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    }

    public string GenerateWhere(IDictionary<string, object> parameters)
    {
        var where = "WHERE ";

        var longitud = parameters.Count();

        foreach (var paramerter in parameters)
        {
            where += longitud is 1
                ? $"{paramerter.Key} = @{paramerter.Key};"
                : $"{paramerter.Key} = @{paramerter.Key} AND ";

            longitud--;
        }

        return where;
    }

    public string GenerateWhereParams(params (string, object)[] parameters)
    {
        var where = "WHERE ";

        var longitud = parameters.Count();

        foreach (var paramerter in parameters)
        {
            where += longitud is 1
                ? $"{paramerter.Item1} = @{paramerter.Item1};"
                : $"{paramerter.Item1} = @{paramerter.Item1} AND ";

            longitud--;
        }

        return where;
    }

    public string GenerateWhereParams(params (string, object, RepositoryEnum)[] parameters)
    {
        var where = "WHERE ";

        var longitud = parameters.Count();

        foreach (var paramerter in parameters)
        {
            string sign = paramerter.Item3 switch
            {
                RepositoryEnum.GreaterThan => ">",
                RepositoryEnum.GreaterThanEqual => ">=",
                RepositoryEnum.LessThan => "<",
                RepositoryEnum.LessThanEqual => "<=",
                RepositoryEnum.Distinct => "<>"
            };
            where += longitud is 1
                ? $"{paramerter.Item1} {sign} @{paramerter.Item1};"
                : $"{paramerter.Item1} {sign} @{paramerter.Item1} AND ";

            longitud--;
        }

        return where;
    }

    public string GenerateWhereBetweenParams(string column, (string, object) init, (string, object) end)
        => $"WHERE {column} BETWEEN @{init.Item1} AND @{end.Item1}";

    public string GenerateWhereInParams((string, object) inside)
    {
        return $"WHERE {inside.Item1} IN @{inside.Item1}";
    }

    public string GenerateWhereInParams(params (string, object[])[] inside)
    {
        string where = "WHERE ";

        var contador = inside.Length;

        foreach (var param in inside)
        {
            if (contador is 1)
            {
                where += $"{param.Item1} IN @{param.Item1} ";
            }
            else
            {
                where += $"{param.Item1} IN @{param.Item1} AND ";
            }

            contador--;
        }

        return where;
    }

    public string GenerateWhereUpdate()
        => "WHERE Id = @Id";

    public string GenerateSelect<T>(string? db = null)
    {
        var campos = "";

        var tabla = typeof(T).Name;

        var propiedades = typeof(T)
            .GetProperties()
            .Select(x => x.Name)
            .ToList();

        var longitud = propiedades.Count();

        propiedades.ForEach(propiedad =>
        {
            campos += longitud is 1 ? $"{propiedad}" : $"{propiedad}, ";
            longitud--;
        });

        return db is null ? $"SELECT {campos} FROM {tabla}" : $"SELECT {campos} FROM {db}.{tabla}";
    }

    public string GenerateInsert<T>(DatabaseEnum databaseEnum, string db = null)
    {
        var columns = "";
        object values = "";

        var tabla = typeof(T).Name;

        var properties = typeof(T)
            .GetProperties()
            .Select(x => x.Name)
            .ToList();

        var longitud = properties.Count;

        properties.ForEach(propiedad =>
        {
            if (propiedad is "Id")
            {
                longitud--;
            }
            else
            {
                columns += longitud is 1 ? propiedad : $"{propiedad},";

                values += longitud is 1 ? $"@{propiedad}" : $"@{propiedad},";

                longitud--;
            }
        });

        if (db is not null)
            return databaseEnum is DatabaseEnum.SQLServer
                ? $"INSERT INTO {db}.{tabla}({columns}) OUTPUT INSERTED.[Id] VALUES({values});"
                : $"INSERT INTO {db}.{tabla}({columns}) VALUES({values}) RETURNING Id;";

        return databaseEnum is DatabaseEnum.SQLServer
            ? $"INSERT INTO {tabla}({columns}) OUTPUT INSERTED.[Id] VALUES({values});"
            : $"INSERT INTO {tabla}({columns}) VALUES({values}) RETURNING Id;";
    }

    public string GenerateUpdate<T>(string db = null)
    {
        var tabla = typeof(T).Name;

        var update = db is null ? $"UPDATE {tabla} SET " : $"UPDATE {db}.{tabla} SET ";

        var properties = typeof(T)
            .GetProperties()
            .Select(x => x.Name)
            .ToList();

        var longitud = properties.Count;

        properties.ForEach(propiedad =>
        {
            if (propiedad is "Id")
            {
                longitud--;
            }
            else
            {
                update += longitud is 1 ? $"[{propiedad}] = @{propiedad}" : $"[{propiedad}] = @{propiedad}, ";

                longitud--;
            }
        });

        return update;
    }
}