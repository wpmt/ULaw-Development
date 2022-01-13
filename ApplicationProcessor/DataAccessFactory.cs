using System;
using System.Collections.Generic;
using System.Text;

namespace Ulaw.ApplicationProcessor
{
    class DataAccessFactory
    {

        public static dynamic GetCustomerDataAccessObj(string faculty, string courseCode, DateTime startdate, string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa)
        {
            return new Applicant(faculty, courseCode, startdate, title, firstName, lastName, dateOfBirth, requiresVisa);
        }
    }
}
