using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoUtDes.Model.ItemShared {
	public interface IItemShare {

		string UniqueId		{ get; set; }
		string Hash			{ get; set; }
		string PublicUrl	{ get; set; }
		string ResourceName { get; set; }
		string Title		{ get; set; }
		string Permissions	{ get; set; }
		string Folder		{ get; set; }
		decimal Size		{ get; set; }

		void Download();
		void Upload();

	}
}
