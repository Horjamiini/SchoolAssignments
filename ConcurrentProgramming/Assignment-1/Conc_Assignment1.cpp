#include <iostream>
#include <thread>
#include <vector>

using namespace std;


void runThreads() {
    for (int i = 0; i < 1000; ++i) {
        std::cout << "Currently on:" << i;
    }
}


int main()
{
    int nThreads = thread::hardware_concurrency();
    std::vector<thread> threads;

    for (int i = 0; i < nThreads; i++) {
        threads.push_back(thread(runThreads));
    }

    for (auto& t: threads) {
        t.join();
    }
}
