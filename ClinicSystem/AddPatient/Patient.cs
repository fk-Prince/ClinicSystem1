using System;

namespace ClinicSystem
{

    
    public class Patient
    {
        private int patientId;
        private int roomNo;
        private int frontdeskId;
        private int doctorIds;
        private int operationCode;
        private string fname;
        private string mname;
        private string lname;
        private int age;
        private string address;
        private string gender;
        private string condition;
        private DateTime birthDate;
        private DateTime dateAdmitted;
        private string ContactNumber;
        private double bill;
        private string status;
        private DateTime dischargedDate;
        private string doctorName;
        private string operationName;

        public Patient(int roomNo, int frontdeskId, int doctorId, int operationCode, string fname, string mname, string lname, int age, string address, string gender, string condition, DateTime birthDate, DateTime dateAdmitted, string contactNumber, double bill)
        {
            this.roomNo = roomNo;
            this.frontdeskId = frontdeskId;
            this.doctorIds = doctorId;
            this.operationCode = operationCode;
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
            this.age = age;
            this.address = address;
            this.gender = gender;
            this.condition = condition;
            this.birthDate = birthDate;
            this.dateAdmitted = dateAdmitted;
            ContactNumber = contactNumber;
            this.bill = bill;
        }

        public Patient(int patientid, int roomNo, int frontdeskId, int doctorId, int operationCode, string fname, string mname, string lname, int age,
            string address, string gender, string condition, DateTime birthDate, DateTime dateAdmitted, string contactNumber, double bill, string status, DateTime dischargedDate)
        {
            this.patientId = patientid;
            this.roomNo = roomNo;
            this.frontdeskId = frontdeskId;
            this.doctorIds = doctorId;
            this.operationCode = operationCode;
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
            this.age = age;
            this.address = address;
            this.gender = gender;
            this.condition = condition;
            this.birthDate = birthDate;
            this.dateAdmitted = dateAdmitted;
            ContactNumber = contactNumber;
            this.bill = bill;
            this.status = status;
            this.dischargedDate = dischargedDate;
        }

        
       
         public void setDoctorName(string doctorName)
        {
            this.doctorName = doctorName;
        }
        public void setOperationName(string operationName)
        {
            this.operationName = operationName;
        }

        public String getDoctorName()
        {
            return doctorName;
        }
        public String getOperationName()
        {
            return operationName;
        }
        public String getStatus()
        {
            return status;
        }
        public DateTime getDischargedDate()
        {
            return dischargedDate;
        }
        public int getRoomNo()
        {
            return roomNo;
        }
        public int getFrontdeskId()
        {
            return frontdeskId;
        }
        public int getPatientId()
        {
            return patientId;
        }
        public int doctorId()
        {
            return doctorIds;
        }
        public int getOperationCode()
        {
            return operationCode;
        }

        public int getAge()
        {
            return age;
        }
        public String getAddress()
        {
            return address;
        }
        public String getGender()
        {
            return gender;
        }
        public String getCondition()
        {
            return condition;
        }
        public DateTime getBirthDate()
        {
            return birthDate;
        }
        public DateTime getDateAdmitted()
        {
            return dateAdmitted;
        }
        public string getContactNumber()
        {
            return ContactNumber;
        }
        public double getBill()
        {
            return bill;
        }
        public String getFname()
        {
            return fname;
        }
        public String getMname()
        {
            return mname;
        }
        public String getLname()
        {
            return lname;
        }


    }
}