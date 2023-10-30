using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestKursach2.Models
{
	public class User
	{
		[HiddenInput]
		public int Id { get; set; }

		[Display(Name = "Прізвище")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "Від 2 до 30")]
		public string LastName { get; set; }

		[Display(Name = "Ім'я")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Від 2 до 20")]
		public string FirstName { get; set; }

		[Display(Name = "Електронна адреса")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(50)]
		[RegularExpression(@"(?<name>[\w.]+)\@(?<domain>\w+\.\w+)(\.\w+)?", ErrorMessage = "Некоректна адреса")]
		public string Email { get; set; }


		[Display(Name = "Пароль")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(30, MinimumLength = 10, ErrorMessage = "Від 10 до 30")]
		public string Password { get; set; }
	}
}