using FormsAssistControl.Model.Entities;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAssistControl
{
	public class StudentsDirectoryVM:ObservableBaseObject
	{


		public ObservableCollection<Student> Students { get; set; }

		bool isBusy = true;

		public bool IsBusy {
			get { return isBusy; }
			set { isBusy = value; OnPropertyChanged(); }
		}


		public Command LoadDirectoryCommand {
			get;set;
		}
		public StudentsDirectoryVM()
		{
			Students = new ObservableCollection<Student>();
			IsBusy = false;
			LoadDirectoryCommand = new Command((obj)=>LoadDirectory());
		}

		async void LoadDirectory() {

			if (!IsBusy) {

				IsBusy = true;
				await Task.Delay(3000);

				var LoadedDirectory = StudentDirectoryService.LoadStudentDirectory();
				foreach (var student in LoadedDirectory.Students)
				{
					Students.Add(student);
				}

				IsBusy = false;
			}
		}
	}
}
