using Newtonsoft.Json;

namespace LibraryManagementApp.Utils;

static class FileHelper
{
    public static async Task<List<T>> ReadFileAsync<T>(string path)
    {
        using StreamReader sr = new StreamReader(path);
        string text = await sr.ReadToEndAsync();

        List<T>? data = JsonConvert.DeserializeObject<List<T>>(text);

        if (data == null)
            return new List<T>();

        return data;
    }

    public static async Task WriteFileAsync<T>(string path, List<T> data)
    {
        string text = JsonConvert.SerializeObject(data);

        using StreamWriter sw = new StreamWriter(path, false);
        await sw.WriteAsync(text);
    }
}
