using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace SampleProject.Application.Utils;

public class ResponseService
{
    private readonly IList<string> _messages = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> Errors { get; }

    public object? Result { get; private set; }

    public string Message => _messages.Count == 0 ? "OK" : string.Join(";", _messages.ToArray());

    public bool Success => _messages.Count == 0 ? true : false;

    public ResponseService() => Errors = new ReadOnlyCollection<string>(_messages);

    public ResponseService(object result) : this() => Result = result;

    public ResponseService AddError(string message)
    {
        _messages.Add(message);
        return this;
    }

    public ResponseService ChangeResult(object result)
    {
        Result = result;
        return this;
    }
}