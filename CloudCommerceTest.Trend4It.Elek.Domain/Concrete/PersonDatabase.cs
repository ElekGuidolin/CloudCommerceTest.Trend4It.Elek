using CloudCommerceTest.Trend4It.Elek.Domain.Interface;
using System;

namespace CloudCommerceTest.Trend4It.Elek.Domain.Concrete
{
    public class PersonDatabase : IPerson
    {

        public string[] GetData(string path)
        {
            throw new NotImplementedException();
        }

        private string DatabaseToJson(string csvValues)
        {
            throw new NotImplementedException();
        }

        public string SaveData(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
