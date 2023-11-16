﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class CourseLogic : ICourseLogic
    {
        ICourseLogic courseRepo;
        public CourseLogic(ICourseLogic courseRepo)
        {
                this.courseRepo=courseRepo;
        }
        public void Create(Game course)
        {
            courseRepo.Create(course);
        }

        public void Delete(int id)
        {
           courseRepo.Delete(id);
        }

        public Game Read(int id)
        {
            return courseRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel kurzust");
        }

        public IEnumerable<Game> ReadAll()
        {
            return courseRepo.ReadAll();
        }

        public void Update(Game course)
        {
            courseRepo.Update(course);
        }
    }
}
