// File:    DoctorService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class DoctorService

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Exceptions;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;

namespace SIMS.Service.UsersService
{
    public class DoctorService : Util.IUserValidation, IService<Doctor, UserID>, IUserService<Doctor>
    {
        DoctorRepository _doctorRepository;

        string usernameRegex = "[a-zA-Z_0-9]+";
        string passwordRegex = "[a-zA-Z_0-9]+";
        string nameRegex = "([A-Z][a-z]+)+";
        string uidnRegex = "[0-9]{13}";
        string emailRegex = "[A-Za-z_.]+@([A-Za-z.])+\\.[a-z]+$";
        string phoneRegex = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- /0-9]*$";

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        public IEnumerable<Doctor> GetActiveDoctors()
        {
            List<Doctor> retVal = new List<Doctor>();

            WorkingDaysEnum dayOfWeek = getDayOfWeek();

            foreach(Doctor d in _doctorRepository.GetAllEager())
            {
                if (d.TimeTable.WorkingHours[dayOfWeek].IsDateTimeBetween(DateTime.Now))
                    retVal.Add(d);
            }

            return retVal;
        }

        public IEnumerable<Doctor> GetDoctorByType(DocTypeEnum doctorType)
            => _doctorRepository.GetDoctorByType(doctorType);

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(Util.TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter)
            => _doctorRepository.GetFilteredDoctors(filter);

        

        public bool CheckUsername(string username)
            => Regex.IsMatch(username, usernameRegex);

        public bool CheckPassword(string password)
            => Regex.IsMatch(password, passwordRegex);

        public bool CheckName(string name)
            => Regex.IsMatch(name, nameRegex);

        public bool CheckUidn(string uidn)
            => Regex.IsMatch(uidn, uidnRegex);

        public bool CheckDateOfBirth(DateTime date)
            => DateTime.Compare(new DateTime(2000, 1, 1), date) > 0;

        public bool CheckEmail(string email)
            => Regex.IsMatch(email, emailRegex);

        public bool CheckPhoneNumber(string phoneNumber)
            => Regex.IsMatch(phoneNumber, phoneRegex);

        public IEnumerable<Doctor> GetAll()
            => _doctorRepository.GetAllEager();

        public Doctor GetByID(UserID id)
            => _doctorRepository.GetByID(id);

        public Doctor Create(Doctor entity)
            => _doctorRepository.Create(entity);

        public void Delete(Doctor entity)
            => _doctorRepository.Delete(entity);

        //TODO: proveriti
        public void Validate(Doctor user)
        {
            if (!CheckDateOfBirth(user.DateOfBirth))
                throw new InvalidUserException("Invalid date of birth!");


            if (!CheckEmail(user.Email1) || !CheckEmail(user.Email2))
                throw new InvalidUserException("Invalid email!");

            if (!CheckName(user.Name))
                throw new InvalidUserException("Invalid name!");

            if (!CheckUsername(user.UserName))
                throw new InvalidUserException("Invalid username!");

            if (!CheckPassword(user.Password))
                throw new InvalidUserException("Invalid password!");

            if (!CheckPhoneNumber(user.CellPhone) || !CheckPhoneNumber(user.HomePhone))
                throw new InvalidUserException("Invalid phone number!");

            if (!CheckUidn(user.Uidn))
                throw new InvalidUserException("Invalid UIDN!");
        }


        //TODO: proveriti
        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor entity)
            => _doctorRepository.Update(entity);

        public IDoctorRepository iDoctorRepository;


        private WorkingDaysEnum getDayOfWeek()
        {
           switch(DateTime.Now.DayOfWeek)
           {
                case DayOfWeek.Monday:
                    return WorkingDaysEnum.MONDAY;
                case DayOfWeek.Tuesday:
                    return WorkingDaysEnum.TUESDAY;
                case DayOfWeek.Wednesday:
                    return WorkingDaysEnum.WEDNESDAY;
                case DayOfWeek.Thursday:
                    return WorkingDaysEnum.THURSDAY;
                case DayOfWeek.Friday:
                    return WorkingDaysEnum.FRIDAY;
                case DayOfWeek.Saturday:
                    return WorkingDaysEnum.SATURDAY;
                default:
                    return WorkingDaysEnum.SUNDAY;
           };
        }
    }
}