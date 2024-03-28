namespace TERA.CA.OnlineBank.Infrastructure.Interface
{
    public interface Ismtp
    {
        void SendMesaage(string to, string body, string subject);
    }
}
