using Monefy.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monefy.Services
{
    public class UserDataService : IUserDataService
    {
        public string Filepath { get; set; } = "UserData.json";

        private UserData? _data;
        public UserData? Data
        {
            get => _data;
            set => Update(value);
        }

        public UserDataService()
        {
            Data = Fetch();   
            if (Data == null)
            {
                CategoryModel[] defaultCategories = new CategoryModel[]{ 
                    new() { Name="Food" },
                    new() { Name="Commuting" },
                    new() { Name="House" },
                    new() { Name="Entertainment" }
                };

                Data = new() { Balance = 0.0f, Categories = defaultCategories };
            }
        }

        public void YieldBalance(float amount)
        {
            Data.Balance += amount;
            Update(Data);
        }

        public void RecordPurchase(PurchaseRecord<float> purchaseRecord)
        {
            if (Data.PurchaseHistory != null)
            {
                List<PurchaseRecord<float>> purchaseRecords = new(Data.PurchaseHistory);
                purchaseRecords.Add(purchaseRecord);
                Data.PurchaseHistory = purchaseRecords.ToArray();
            }
            else
            {
                Data.PurchaseHistory = new PurchaseRecord<float>[] { purchaseRecord };
            }

            Update(Data);
        }

        private void Update(UserData? userData)
        {
            using FileStream fs = new(Filepath, FileMode.Create);

            JsonSerializer.Serialize(fs, userData);

            _data = userData;
        }

        private UserData? Fetch()
        {
            using FileStream fs = new(Filepath, FileMode.OpenOrCreate);

            UserData? userData = null;

            try
            {
                userData = JsonSerializer.Deserialize<UserData>(fs);
            }
            catch (JsonException) { }

            return userData;
        }

    }
}
