public interface IWindow
{
    string Id { get; }
    void Initialize(string id);
    void Open();
    void Close();
}
