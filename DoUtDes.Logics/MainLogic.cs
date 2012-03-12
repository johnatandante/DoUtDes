using System;
using System.Collections.Generic;
using DoUtDes.Model.Settings;
using DoUtDes.Model.Account;
using DoUtDes.Model.Enums;

namespace DoUtDes.Logics.Phone {
	public class MainLogic {

		private List<AccountInfo> _accounts = new List<AccountInfo>();
		private Settings _settings = Settings.Instance;

		public MainLogic()
		{
		    // LoadAccountInfo();
			// ReadSharedItems();
			// SyncronizeAccounts();
			
		}

        private void LoadAccountInfo()
        {
            throw new NotImplementedException();
        }

		private void SyncronizeAccounts() {
			throw new NotImplementedException();
		}

		private void ReadSharedItems() {
			throw new NotImplementedException();
		}


        public List<AccountInfo> GetAccounts()
        {
            // LoadAccountInfo();
            var accounts = new List<AccountInfo>()
                       {
                            new AccountInfo() { Email = "dante.delfavero@gmail.com", UniqueId = Guid.NewGuid().ToString(), Account = AccountType.Facebook },
                            new AccountInfo() { Email = "dantiii@libero.com", UniqueId = Guid.NewGuid().ToString(), Account = AccountType.Dropbox },
                            new AccountInfo() { Email = "danteTheBrave", UniqueId = Guid.NewGuid().ToString(), Account = AccountType.Skydrive }
                       };

            accounts.ForEach(x => x.AvatarIconUri = StorageAccount.GetIconUri(x.Account));
            return accounts;
        }
    }
}
