#include <iostream>
#include <thread>
#include <vector>
#include <random>
#include <time.h>



using namespace std;
int nNumber;
std::vector<int> numbers;


void  randomizeNum() {

	srand(time(0));
	int og_numbers = numbers.size();

	for (int i = 0; i < og_numbers; ++i)
	{
		
		generate(numbers.begin(), numbers.end(), rand);

	};

	for (auto i : numbers)
	{
		std::cout << i << "\n";
	};

}




int main()
{
	std::cout << "How many numbers do you want to allocate? ";
	std::cin >> nNumber;


	for (int i = 0; i < nNumber; ++i)
	{
		numbers.push_back(i);
	};


	std::cout << "Allocated numbers\n";

	for (auto i : numbers)
		{
			std::cout << i << "\n" ;
		};

	thread t1(randomizeNum);
	std::cout << "\nmain:started thread\n\n";

	t1.join();
}

