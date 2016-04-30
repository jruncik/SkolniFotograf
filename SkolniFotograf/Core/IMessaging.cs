namespace SkolniFotograf.Core
{
    public interface IMessaging
    {
        void AddError(string message);

        void AddMessage(string message);

        void AddNewLine();

        void ClearMessages();
    }
}
