using DEG.Emfluence.Models;
using DEG.ServiceCore;
using DEG.ServiceCore.Authentication;

namespace DEG.Emfluence
{
    /// <summary>
    /// Simple interface for interacting with the Emfluence API v1: https://apidocs.emailer.emfluence.com/v1/
    /// </summary>
    public class EmfluenceService : ServiceBase
    {
        protected readonly string BaseServiceUrl = "https://api.emailer.emfluence.com/v1/";

        public EmfluenceService(IServiceAuth auth) : base(auth) { }

        public SaveContactResponse SaveContact(ContactData contact)
        {
            var url = BaseServiceUrl + "contacts/save";
            return SubmitObject<SaveContactResponse, ContactData>(url, contact);
        }
    }
}
