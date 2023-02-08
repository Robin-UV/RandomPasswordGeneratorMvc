using System;

namespace RandomPasswordGeneratorMvc.Models
{
	public class PasswordViewModel
	{
		public string GeneratedPassword { get; set; } = null!;
		public int PasswordLength { get; set; }
		public bool IncludeUpperCase { get; set; }
		public bool IncludeSpecialCharacters { get; set; }
	}
}

