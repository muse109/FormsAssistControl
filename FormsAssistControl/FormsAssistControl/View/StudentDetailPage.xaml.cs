using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsAssistControl.View
{
    public partial class StudentDetailPage : ContentPage
    {
        public StudentDetailPage( Student selectedStudent)
        {
            InitializeComponent();


            this.BindingContext = selectedStudent;
        }
    }
}
