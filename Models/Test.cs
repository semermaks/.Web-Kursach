using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestKursach2.Models
{
	public class Test
	{
		[HiddenInput]
		public int Id { get; set; }

		[Display(Name = "Названня тесту")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		[StringLength(100, MinimumLength = 10, ErrorMessage = "Від 10 до 100")]
		public string Name { get; set; }

		[Display(Name = "Довжина тесту(в хвилинах)")]
		[Required(ErrorMessage = "Обов'язкове поле")]
		public double Time { get; set; }
		public virtual ICollection<Question> Questions { get; set; }

		[HiddenInput]
		public int OvnerId { get; set; }

		public Test()
		{
			Questions = new List<Question>();
		}
	}
}