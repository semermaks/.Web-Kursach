using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestKursach2.Models
{
	public class Question
	{
		[HiddenInput]
		public int Id { get; set; }

		[Display(Name = "Питання")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Від 3 до 100")]
		public string Text { get; set; }

		[Display(Name = "Відповідь 1")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Від 3 до 100")]
		public string Answer1 { get; set; }

		[Display(Name = "Відповідь 2")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Від 3 до 100")]
		public string Answer2 { get; set; }

		[Display(Name = "Відповідь 3")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Від 3 до 100")]
		public string Answer3 { get; set; }

		[Display(Name = "Відповідь 4")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Від 3 до 100")]
		public string Answer4 { get; set; }

		[Display(Name = "Посилання по темі")]
		[StringLength(100, MinimumLength = 1, ErrorMessage = "Від 1 до 100")]
		public string Site { get; set; }

		[Display(Name = "1 - правильна відповідь?")]
		public bool Answer1Right { get; set; } = false;
		[Display(Name = "2 - правильна відповідь?")]
		public bool Answer2Right { get; set; } = false;
		[Display(Name = "3 - правильна відповідь?")]
		public bool Answer3Right { get; set; } = false;
		[Display(Name = "4 - правильна відповідь?")]
		public bool Answer4Right { get; set; } = false;

		[HiddenInput]
		public int OvnerId { get; set; }
	}
}