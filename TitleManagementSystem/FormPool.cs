namespace TitleManagementSystem
{
    public abstract class FormPool
    {
        public static ProfileDatabase ProfileDatabase = new ProfileDatabase();
        public static UserDatabase UserDatabase = new UserDatabase();
        public static TransferHistory TransferHistory = new TransferHistory();
        
    }
}