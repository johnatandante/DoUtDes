using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoUtDes.Model.ItemShared {
	public class ItemShare : IItemShare, IStorable, IReadable {


		#region Interface IStoreable

		public void UpdateInfo() {
			throw new NotImplementedException();
		}

		#endregion

		#region Interface IReadable

		public void ReadInfo() {
			throw new NotImplementedException();
		}

		#endregion

		#region Interface IItemShare

		public string UniqueId { get; set; }
		public string Hash { get; set; }
		public string PublicUrl { get; set; }
		public string ResourceName { get; set; }
		public string Title { get; set; }
		public string Permissions { get; set; }
		public string Folder { get; set; }
		public decimal Size { get; set; }

		public void Download() {
			throw new NotImplementedException();
		}

		public void Upload() {
			throw new NotImplementedException();
		}

		#endregion
	}

}
