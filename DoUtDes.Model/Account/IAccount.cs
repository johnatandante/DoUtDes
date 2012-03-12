using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoUtDes.Model.Account {
	public interface IAccount {

		string UniqueId { get; set; }
		string Email { get; set; }
		string PasswordHash { get; set; }

		string GetPassword(string hash, string publicKey);

	}
}
