using System;
using System.Text;
using Ulaw.ApplicationProcessor;
using ULaw.ApplicationProcessor.Enums;  

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        dynamic applicant;
        public Application(string faculty, string CourseCode, DateTime Startdate, string Title, string FirstName, string LastName, DateTime DateOfBirth, bool requiresVisa)
        {
            this.applicant = DataAccessFactory.GetCustomerDataAccessObj(faculty, CourseCode, Startdate, Title, FirstName, LastName, DateOfBirth, requiresVisa);
        }
        public DegreeGradeEnum DegreeGrade
        {
            get => applicant.DegreeGrade;
            set => applicant.DegreeGrade = value;
        }

        public DegreeSubjectEnum DegreeSubject
        {
            get => applicant.DegreeSubject;
            set => applicant.DegreeSubject = value;
        }

        public string Process()
        {
            var result = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");

            if (applicant.DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                result.Append(string.Format("<p> Dear {0}, </p>", applicant.FirstName));
                result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", applicant.CourseCode, applicant.StartDate.ToLongDateString()));
                result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");

            }
            else
            {
                if (applicant.DegreeGrade == DegreeGradeEnum.third)
                {
                    result.Append(string.Format("<p> Dear {0}, </p>", applicant.FirstName));
                    result.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
                    result.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");

                }
                else
                {
                    if (applicant.DegreeSubject == DegreeSubjectEnum.law || applicant.DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
                    {
                        decimal depositAmount = 350.00M;

                        result.Append(string.Format("<p> Dear {0}, </p>", applicant.FirstName));
                        result.Append(string.Format("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", applicant.CourseCode, applicant.StartDate.ToLongDateString()));
                        result.Append(string.Format("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", DegreeSubject.ToDescription(), DegreeGrade.ToDescription()));
                        result.Append(string.Format("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString()));
                        result.Append(string.Format("<br/> We look forward to welcoming you to the University,"));

                    }
                    else
                    {
                        result.Append(string.Format("<p> Dear {0}, </p>", applicant.FirstName));
                        result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", applicant.CourseCode, applicant.StartDate.ToLongDateString()));
                        result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");

                    }
                }
            }

            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            result.Append(string.Format("</body></html>"));

            return result.ToString();
        }

    }
}

