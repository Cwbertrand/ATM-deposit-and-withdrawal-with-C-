public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    //the __construct magic method in C#
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //make getters in C#
    public string getCardNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    //make setters in C#
    public void setCardNum(string cardNum)
    {
        this.cardNum = cardNum;
    }
    public void setPin(int pin)
    {
        this.pin = pin;
    }
    public void setFirstName(string firstName)
    {
        this.firstName = firstName;
    }
    public void setLastName(string lastName)
    {
        this.lastName = lastName;
    }
    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    //Creating the ATM method
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your money, your new balance is: " + currentUser.getBalance());
        }

        //Withdrawal method
        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());

            //Checking if the user has enough money to withdraw
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                //else you calculate the withdrawal and give the balance
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");

            }
        }

        //Get the balance
        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        //Setting up a default library, like a database
        
        //creating a list in C#
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("343203495459293834584", 1243, "John", "Griffith", 150.32));
        cardHolders.Add(new CardHolder("553230569892323426788", 5674, "Bert", "Joe", 439.23));
        cardHolders.Add(new CardHolder("354567086532312136457", 5345, "George", "Mandisen", 343.34));
        cardHolders.Add(new CardHolder("986577778098789032212", 6854, "William", "Michel", 366.32));
        cardHolders.Add(new CardHolder("656788888888898065434", 3246, "Bauer", "Eric", 633.45));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please enter a debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;

        //this while loop is to say if the user continues to insert wrong debit card, it will just keep prompting
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();

                //check if the user's info is in the db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized, Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized, Please try again");
            }
        }

        Console.WriteLine("Please enter you pin: ");

        int userPin = 0;
        while (true)
        {
            try
            {
                //the pin the user inserted
                userPin = int.Parse(Console.ReadLine());

                //check if the user's info is in the db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin, Please try again"); }
            }
            catch
            {
                Console.WriteLine("Incorrect pin, Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            //this prints the option like 1...4 to the user
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
            Console.WriteLine("Thank you! Have a nice day :)");
    }



}