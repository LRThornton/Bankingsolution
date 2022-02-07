using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking {
    public class Account {

        //Static Properties this below creates an account number and gives it initial value
        private static int NextAccountNumber { get; set; } = 1; 
        
        //these are the Instance properties
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public string Description { get; set; }

        // Methods
        public bool Deposit(decimal Amount) {
            if(Amount <= 0) {
                throw new Exception("Amount must be positive.");
            }
            Balance = Balance + Amount;
            return true;
        }
        public bool Withdraw(decimal Amount) {
            if (Amount <= 0) {
                throw new Exception("Amount must be positive.");
            }
            
            if(Amount > Balance) {
                throw new Exception("Insufficient Funds!");
            }
            Balance = Balance - Amount;
            return true;
        } 
        public bool Transfer(decimal Amount, Account ToAccount) {
            try {
                Withdraw(Amount);
             }catch (Exception) {
                throw new Exception("Withdraw failed in transfer.");
            }
            ToAccount.Deposit(Amount);
            return true;
        }
        public void Debug() {
            Console.WriteLine($"{AccountNumber} | {Description} | {Balance:c}");
        }
        // Constructors
        public Account() { // this is called the default constructor and contains no parameters
            AccountNumber = NextAccountNumber;
            NextAccountNumber++; //this increments the account number to 2 then 3 and so forth
            Description = "New Account";
            Balance = 0;

        }


    }
}
