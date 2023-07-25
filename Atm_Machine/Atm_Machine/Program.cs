using System;

public class CardHolder
{
    String CardNum;
    int Pin;
    string firstname;
    string Lastname;
    double Balance;

    public CardHolder(String CardNum, int Pin, string firstname, string Lastname, double Balance)
    {
        this.CardNum = CardNum;
        this.Pin = Pin;
        this.firstname = firstname;
        this.Lastname = Lastname;
        this.Balance = Balance;
    }

    public String getNum()
    {
        return this.CardNum;
    }

    public int getPin()
    {
        return this.Pin;
    }

    public String getfirstname()
    {
        return this.firstname;
    }

    public String getLastname()
    {
        return this.Lastname;
    }

    public double getBalance()
    {
        return this.Balance;
    }

    public void setNum(String newCardNum)
    {
        this.CardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        this.Pin = newPin;
    }

    public void setfirstname(String newfirstname)
    {
        this.firstname = newfirstname;
    }

    public void setLastname(String newLastname)
    {
        this.Lastname = newLastname;
    }

    public void setBalance(double newBalance)
    {
        this.Balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from the following options ....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. EXIST");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance()+deposit);
            Console.WriteLine("Thankyou for yous $$. Your new Balance : " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to Wihdrawal: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient Balnace");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go. Thankyou ");
            }
        }
        void Balance(CardHolder currentUser)
        {
            Console.WriteLine("Current Balnace " + currentUser.getBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("1111111111", 9045, "Vikas", "Choudhary", 45000));
        cardHolders.Add(new CardHolder("9999999999", 9389, "Prashant", "Pal", 55000));
        cardHolders.Add(new CardHolder("8888888888", 8755, "Manu", "Choudhary", 6000));
        cardHolders.Add(new CardHolder("7777777777", 9999, "Shivam", "Kumar", 5000));
        cardHolders.Add(new CardHolder("6666666666", 8888, "Vishal", "Sharma", 7000));


        Console.WriteLine("Welcome to MY ATM ");
        Console.WriteLine("Enter your Card number: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.CardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card dont recognize . Try Again !"); }
            }
            catch
            {
                Console.WriteLine("Card dont recognize . Try Again !");
            }
        }

        Console.WriteLine("Enter your PIN : ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Try Again !"); }
            }
            catch
            {
                Console.WriteLine("Incorrect PIN. Try Again !");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getfirstname() + " "  + currentUser.getLastname() +":) "); 
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { Balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thanks Have A Nice Day");
    }
}