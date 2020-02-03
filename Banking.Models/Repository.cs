using System.IO;
using Newtonsoft.Json;
namespace Banking.Models{
    public class Repository:IRepository{
        public string BasePath {get; private set;} 
        public IFile MyFile;
        public Repository(string basePath,IFile file) => (BasePath,MyFile) = (basePath,file);
        public void Save(IAccount account){            
            var filePath = Path.Combine(BasePath+@"\Repository\", $"{account.Id}.acc");
            MyFile.WriteAllText(filePath, JsonConvert.SerializeObject(account));
        }
        public IAccount GetAccount(int AccountId,IAccountFactory factory){
            var filePath = Path.Combine(BasePath+@"\Repository\", $"{AccountId}.acc");
            if(MyFile.Exists(filePath)){
                var existingFileData= MyFile.ReadAllText(filePath);
                var accountDTO=JsonConvert.DeserializeObject<AccountDTO>(existingFileData);
                IAccount acc=factory.CreateAccount(accountDTO);                
                return acc;
            }
            return null;
        }
    }
}
