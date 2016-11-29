﻿using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FormsAssistControl
{
	public class StudentDirectoryService
	{
		public static StudentDirectory LoadStudentDirectory()
		{
			var dbManager = new DatabaseManager();
			ObservableCollection<Student> students = new ObservableCollection<Student>( dbManager.GetAllItems<Student>());

			var studentDirectory = new StudentDirectory();


			if (students.Any()) {

				studentDirectory.Students = students;
				return studentDirectory;
			}

		  

			students = new ObservableCollection<Student>();

			string[] names = { "José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio",
								"Sofía", "Camila", "Valentina", "Isabella", "Ximena"};
			string[] lastNames = { "Hernández", "García", "Martínez", "López", "González" };

			var rdn = new Random(DateTime.Now.Millisecond);

			students = new ObservableCollection<Student>();

			for (int i = 0; i < 20; i++)
			{
				var group = rdn.Next(456, 458).ToString();

				var student = new Student();
				student.Name = names[rdn.Next(0, 8)];
				student.LastName = $"{lastNames[rdn.Next(0, 5)]} {lastNames[rdn.Next(0, 5)]}";
				student.Group = group;
				student.StudentNumber = rdn.Next(12384748, 32384748).ToString();
				student.Average = rdn.Next(100, 1000) / 10;
				student.Key = student.StudentNumber;

				students.Add(student);

				dbManager.SaveValue<Student>(student);

			}
			studentDirectory.Students = students;
			return studentDirectory;
		}
	}
}
