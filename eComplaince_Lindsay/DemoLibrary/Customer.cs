using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Sep.2018
 * Author: Lindsay
 * Purpose: code challenge for eComplaince
 */
namespace DemoLibrary
{
    public class Customer
    {
        private string custId;
        public string CustId
        {
            get
            {
                return custId;
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("CustomerId");
                custId = value;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //constructor
        public Customer(string Id, string fName, string lName)
        {
            CustId = Id;
            FirstName = fName;
            LastName = lName;
        }

    }
}
