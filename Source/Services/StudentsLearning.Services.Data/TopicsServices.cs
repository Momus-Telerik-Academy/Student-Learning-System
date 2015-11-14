﻿namespace StudentsLearning.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;


    public class TopicsServices : ITopicsServices
    {
        private readonly IRepository<Topic> topics;
        private readonly IRepository<ZipFile> zipFiles;


        public TopicsServices(IRepository<Topic> topicsRepo, IRepository<ZipFile> zipFilesRepo)
        {
            this.topics = topicsRepo;
            this.zipFiles = zipFilesRepo;
        }

        public void Add(Topic topic, ICollection<ZipFile> files, ICollection<Example> examples)
        {
            foreach (var example in examples)
            {
                topic.Examples.Add(example);
            }

            foreach (var file in files)
            {
                topic.ZipFiles.Add(file);
            }

            this.topics.Add(topic);
            this.topics.SaveChanges();
        }

        public IQueryable<Topic> All(int sectionId, int page = 1, int pageSize = 10)
        {
            return this.topics
                .All()
                .Where(x => x.Section.Id == sectionId)
                .OrderByDescending(pr => pr.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<Topic> GetById(int id)
        {
            return this.topics
                       .All()
                       .Where(x => x.Id == id);
        }

        public IQueryable<Topic> GetByTitle(string title)
        {
            return this.topics
                .All()
                .Where(x => x.Title == title);
        }

        public void Update(Topic topic, ZipFile newfile, ICollection<Example> newExamples)
        {
            topic
                .Examples
                .ToList()
                .ForEach(i => topic.Examples.Remove(i));
            foreach (var example in newExamples)
            {
                topic.Examples.Add(example);
            }


            this.topics
                .Update(topic);

            this.topics
                .SaveChanges();
        }

        //private int GetZipFileId(Topic topic, ZipFile file)
        //{
        //    var id = this.zipFiles
        //       .All()
        //       .Where(x => x.Id == file.Id)
        //       .Select(i => i.Id)
        //       .FirstOrDefault();
        //    return id;
        //}
    }
}
