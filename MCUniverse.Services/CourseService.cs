﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Models;
using MCUniverse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace MCUniverse.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCourse(CourseCreate newCourse)
        {
            var course = new CourseEntity()
            {
                Name = newCourse.Name,
                Faculty_id = newCourse.Faculty_id,
                startTime = newCourse.startTime,
                endTime = newCourse.endTime,
                classDays = newCourse.classDays,
                Credits = newCourse.Credits,
                Building = newCourse.Building,
                roomNumber = newCourse.roomNumber
            };
            _context.Courses.Add(course);
            var numChanges = await _context.SaveChangesAsync();
            return numChanges == 1;
        }

        public async Task<IEnumerable<CourseDetail>> ShowAllCourses()
        {
            var courses = await _context.Courses
                .Select(entity => new CourseDetail
                {
                    Name = entity.Name,
                    startTime = entity.startTime,
                    endTime = entity.endTime,
                    classDays = entity.classDays,
                    Credits = entity.Credits,
                    Building = entity.Building,
                    roomNumber = entity.roomNumber
                }).ToListAsync();
            return courses;
        }

        public async Task<CourseDetail?> ShowCoursebyId(int id)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(e =>
                e.Id == id);
            return course is null ? null : new CourseDetail
            {
                Name = course.Name,
                startTime = course.startTime,
                endTime = course.endTime,
                classDays = course.classDays,
                Credits = course.Credits,
                Building = course.Building,
                roomNumber = course.roomNumber
            };
        }

        public ActionResult Index()
        {
            var query = (from faculty in _context.Faculties
                         join course in _context.Courses on faculty.Id equals course.Faculty_id
                         select new
                         {
                             Professor = faculty.Name
                         });
            return Professor;
        }

    };

}

    }
}
