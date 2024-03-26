#include <iostream>
#include <thread>
#include <vector>
#include <mutex>
#include <stdlib.h>    
#include <time.h> 


using namespace std;

mutex m;

void Inc(vector<int>& Numbers)
{
    srand(time(NULL));
    if (m.try_lock())
    {
        for (int i = 0; i < 20; ++i)
        {
            Numbers.push_back(rand());
        }
        m.unlock();
    }
};


void Dec(vector<int>& Numbers)
{
    if (m.try_lock())
    {
        if (Numbers.size() > 1)
        {
            Numbers.pop_back();
        }
        m.unlock();
    }
};


int main()
{
    vector<int> Numbers;


    thread t1(Inc, ref(Numbers));
    thread t2(Dec, ref(Numbers));

    t1.join();
    t2.join();
 

 
    m.lock();
        for (auto num : Numbers)
        {
            cout << num << "\n";
        }
    m.unlock();
    
    cout << "Program exiting";
    
}
