using System.IO;

namespace Banking.Models{
    public class MyFile:IFile{
        public void WriteAllText(string path,string text){
            File.WriteAllText(path,text);
        }
        public string ReadAllText(string path){
            return File.ReadAllText(path);
        }
        public bool Exists(string path){
            return File.Exists(path);
        }
    }
}