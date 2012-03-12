using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoUtDes.Logics {
	public class MainLogic {

		private List<Account> Accounts = new List<Account>();
		private object settings = new object(){ };

		public MainLogic() {

			ReadConfiguration();
			ReadSharedItems();
			SyncronizeAccounts();
			
		}

		private void SyncronizeAccounts() {
			throw new NotImplementedException();
		}

		private void ReadSharedItems() {
			throw new NotImplementedException();
		}

		private void ReadConfiguration() {
			
		}

	}
}
