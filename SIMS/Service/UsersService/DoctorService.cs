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
using SIMS.Util;

namespace SIMS.Service.UsersService
{
    public class DoctorService : IService<Doctor, UserID>, IUserService<Doctor>
    {
        DoctorRepository _doctorRepository;
        UserValidation _userValidation;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _userValidation = new UserValidation();
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



        public IEnumerable<Doctor> GetAll()
            => _doctorRepository.GetAllEager();

        public Doctor GetByID(UserID id)
            => _doctorRepository.GetByID(id);

        public Doctor Create(Doctor entity)
        {
            Validate(entity);
            return _doctorRepository.Create(entity);
        }

        public void Delete(Doctor entity)
            => _doctorRepository.Delete(entity);

        //TODO: proveriti
        public void Validate(Doctor user)
            => _userValidation.Validate(user);


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