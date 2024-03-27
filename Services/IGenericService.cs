namespace PbLabourStatic.Services
{
    public interface IGenericService
    {
        string GetMessage(string saved);

    }

    public class GenericService : IGenericService
    {
        public string GetMessage(string saved)
        {
            string msg = null;
            switch (saved)
            {
                case "1":
                    msg = "Data saved successfully.";
                    break;
                case "2":
                    msg = "Data updated successfully.";
                    break;
                case "3":
                    msg = "Data deleted successfully";
                    break;
                case "4":
                    msg = "Password updated successfully";
                    break;
                case "5":
                    msg = "Password reset successful";
                    break;
                default:
                    msg = null;
                    break;
            }

            return msg;
        }
    }
}
