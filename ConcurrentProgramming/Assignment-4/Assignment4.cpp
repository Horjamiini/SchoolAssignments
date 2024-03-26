#include <iostream>
#include <thread>
#include <mutex>



using namespace std;
mutex m1;

class Banking
{
public:
	Banking(int balance, string account) :
		m_pBalance(balance),
		m_pName(account)
	{
	}

	void deposit(int sum)
	{
		m_pBalance += sum;
	}

	void withdraw(int sum)
	{
		m_pBalance -= sum;
	}

	void account_balance()
	{
		cout << m_pName << " balance is: " << m_pBalance << endl;
	}

private:
	int			m_pBalance;
	string		m_pName;
};

void banking_actions(Banking& bank_account1, Banking& bank_account2)
{
	int count = 5;

	while (count--)
	{
		m1.lock();
		
		int transaction = (rand() % 100);

		bank_account1.deposit(transaction);
		bank_account2.withdraw(transaction);
		//Rich get richer and poor get poorer

		bank_account1.account_balance();
		bank_account2.account_balance();

		m1.unlock();
	}
}


int main()
{
	Banking bank_account1{ 10000, "Rich"};
	Banking bank_account2{ 100, "Poor"};

	thread t1(banking_actions, ref(bank_account1), ref(bank_account2));
	thread t2(banking_actions, ref(bank_account1), ref(bank_account2));
	thread t3(banking_actions, ref(bank_account1), ref(bank_account2));
	thread t4(banking_actions, ref(bank_account1), ref(bank_account2));

	if (t1.joinable())
	{
		t1.join();
	}

	if (t2.joinable())
	{
		t2.join();
	}

	if (t3.joinable())
	{
		t3.join();
	}
	if (t4.joinable())
	{
		t4.join();
	}
}