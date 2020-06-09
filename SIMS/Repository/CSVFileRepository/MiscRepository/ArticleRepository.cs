// File:    ArticleRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:38:19
// Purpose: Definition of Class ArticleRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class ArticleRepository : CSVRepository<Article, long>, IArticleRepository, IEagerCSVRepository<Article, long>
    {
        
        private IDoctorRepository _doctorRepository;
        private IManagerRepository _managerRepository;
        private ISecretaryRepository _secretaryRepository;

        public ArticleRepository(string entityName, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository, ICSVStream<Article> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Article>())
        {
            
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public new Article Create(Article article)
        {
            article.Date = DateTime.Now;
            return base.Create(article);
        }

        public void BindArticlesWithAuthors(IEnumerable<Article> articles)
        {
            IEnumerable<Article> doctorArticles = articles.ToList().Where(article => article._author.GetId().ToString().ToLower().StartsWith("d"));
            IEnumerable<Article> managerArticles = articles.ToList().Where(article => article._author.GetId().ToString().ToLower().StartsWith("m"));
            IEnumerable<Article> secretaryArticles = articles.ToList().Where(article => article._author.GetId().ToString().ToLower().StartsWith("s"));

            IEnumerable<Doctor> doctors = _doctorRepository.GetAll();
            IEnumerable<Manager> managers = _managerRepository.GetAll();
            IEnumerable<Secretary> secretaries = _secretaryRepository.GetAll();

            BindArticlesWithDoctor(doctors, doctorArticles);
            BindArticlesWithManager(managers, managerArticles);
            BindArticlesWithSecretary(secretaries, secretaryArticles);
        }

        public void BindArticlesWithDoctor(IEnumerable<Doctor> doctors, IEnumerable<Article> articles)
            => articles.ToList().ForEach(article => article.Author = GetDoctorById(doctors, article.Author.GetId()));

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, UserID id)
            => doctors.ToList().SingleOrDefault(doctor => doctor.GetId().Equals(id));

        public void BindArticlesWithSecretary(IEnumerable<Secretary> secretaries, IEnumerable<Article> articles)
            => articles.ToList().ForEach(article => article.Author = GetSecretaryById(secretaries, article.Author.GetId()));

        private Secretary GetSecretaryById(IEnumerable<Secretary> secretaries, UserID id)
            => secretaries.ToList().SingleOrDefault(secretary => secretary.GetId().Equals(id));

        public void BindArticlesWithManager(IEnumerable<Manager> managers, IEnumerable<Article> articles)
            => articles.ToList().ForEach(article => article.Author = GetManagerById(managers, article.Author.GetId()));
        
        private Manager GetManagerById(IEnumerable<Manager> managers, UserID id)
            => managers.ToList().SingleOrDefault(manager => manager.GetId().Equals(id));



        public IEnumerable<Article> GetArticleByAuthor(Employee author)
            => GetAll().ToList().Where(article => article.Author.GetId().Equals(author.GetId()));

        public Article GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(article => article.GetId() == id);

        public IEnumerable<Article> GetAllEager()
        {
            var articles = GetAll();
            BindArticlesWithAuthors(articles);
            return articles;
        }

    }
}