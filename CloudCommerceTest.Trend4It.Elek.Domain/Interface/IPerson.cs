using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCommerceTest.Trend4It.Elek.Domain.Interface
{
    public interface IPerson
    {
        string[] GetData(string path);

        string SaveData(string[] lines);
    }
}
