using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoLibrary.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public IList<CourseTag> Tags { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CourseTag> Courses { get; set; }
    }

    public class CourseTag
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }
}
