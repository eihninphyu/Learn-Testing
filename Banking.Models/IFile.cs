namespace Banking.Models{
    public interface IFile{
        void WriteAllText(string path,string text);
        string ReadAllText(string path);
        bool Exists(string path);
    }
}