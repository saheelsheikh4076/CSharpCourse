namespace ECommerce.Models
{
    public class AppKeys
    {
        public AppKeys()
        {
            this.DataProtectionKey = "MyPrivateKey";
        }
        public string DataProtectionKey { get; }
    }
}
