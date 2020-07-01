using GalaSoft.MvvmLight;
using System.Security.Cryptography.X509Certificates;
using Project_Z_UI.UserModel;
using System.Collections.ObjectModel;

namespace Project_Z_UI.ViewModel
{
 
    public class MainViewModel : ViewModelBase
    {
    
        public MainViewModel()
        {
            InitUserCtDbBar();


        }
        public ObservableCollection<UserCtDb> UserCtDbs { get; set; }
        public void InitUserCtDbBar() 
        {
            UserCtDbs = new ObservableCollection<UserCtDb>(); 
            UserCtDbs.Add(new UserCtDb() { username = "mylist" ,usermotto ="What's up!"});
        }
    } 
}