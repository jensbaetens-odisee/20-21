using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry
{
    public class Registry
    {
        private IBezoekerRepository bezoekerRepository;
        private IContactRepository contactRepository;

        public Registry(IBezoekerRepository bezoeker)
            : this(bezoeker, new ContactRepository())
        {

        }

        public Registry(IBezoekerRepository bezoeker, IContactRepository contactRepository)
        {
            this.bezoekerRepository = bezoeker;
            this.contactRepository = contactRepository;
        }

        public bool Register(string email, string name)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public string GetGreeting()
        {
            throw new NotImplementedException();
        }

        public void AddContact(string firstName, string lastName, string email, string location)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public void SendCoronaWarning()
        {
            throw new NotImplementedException();
        }
    }
}
