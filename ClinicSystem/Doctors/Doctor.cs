using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem
{
    public class Doctor
    {

        private int doctorId;
        private int operationCode;
        private string doctorFName;
        private string doctorMName;
        private string doctorLName;
        private int doctorAge;
        private string doctorAddress;
        private string doctorGender;
        private string doctorContactNumber;
        private DateTime doctorDateHired;
        private string doctorPIN;
        private List<string> operationName;
        public Doctor(int doctorId, int operationCode, string doctorFName, string doctorMName, string doctorLName, int doctorAge, string doctorAddress, string doctorGender, string doctorContactNumber, DateTime doctorDateHired, string doctorPIN)
        {
            this.doctorId = doctorId;
            this.operationCode = operationCode;
            this.doctorFName = doctorFName;
            this.doctorMName = doctorMName;
            this.doctorLName = doctorLName;
            this.doctorAge = doctorAge;
            this.doctorAddress = doctorAddress;
            this.doctorGender = doctorGender;
            this.doctorContactNumber = doctorContactNumber;
            this.doctorDateHired = doctorDateHired.Date;
            this.doctorPIN = doctorPIN;
        }

        public Doctor(int doctorId, string doctorFName, string doctorMName, string doctorLName, int doctorAge, string doctorAddress,
            string doctorGender, string doctorContactNumber, DateTime doctorDateHired, List<string> operationName)
        {
            this.operationName = operationName;
            this.doctorId = doctorId;
            this.doctorFName = doctorFName;
            this.doctorMName = doctorMName;
            this.doctorLName = doctorLName;
            this.doctorAge = doctorAge;
            this.doctorAddress = doctorAddress;
            this.doctorGender = doctorGender;
            this.doctorContactNumber = doctorContactNumber;
            this.doctorDateHired = doctorDateHired.Date;
        }

        public List<String> getOperationNames()
        {
            return operationName;
        }
        public int getDoctorID()
        {
            return doctorId;
        }
        public int getOperationCode()
        {
            return operationCode;
        }
        public string getDoctorFName()
        {
            return doctorFName;
        }
        public string getDoctorMName()
        {
            return doctorMName;
        }
        public string getDoctorLName()
        {
            return doctorLName;
        }
        public int getDoctorAge()
        {
            return doctorAge;
        }
        public string getDoctorAddress()
        {
            return doctorAddress;
        }
        public string getDoctorGender()
        {
            return doctorGender;
        }
        public string getDoctorContactNumber()
        {
            return doctorContactNumber;
        }
        public DateTime getDoctorDateHired()
        {
            return doctorDateHired;
        }
        public string getDoctorPIN()
        {
            return doctorPIN;
        }

    }
}
